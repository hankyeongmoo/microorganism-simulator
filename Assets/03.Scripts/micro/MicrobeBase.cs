using UnityEngine;
using System.Collections;

public abstract class MicrobeBase : MonoBehaviour
{
    [Header("Base Stats")]
    public float energy = 50f;
    public float maxEnergy = 100f;
    public float speed = 2f;
    public float detectionRange = 5f;
    public float energyLossRate = 1f;

    private Vector2 randomDir;
    private float survivalTime;
    private float reproductionCooldown = 5f;

    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError($"{gameObject.name}에 Rigidbody2D가 없습니다! 컴포넌트를 추가해주세요.");
        }
        survivalTime = 0f;
        StartCoroutine(MoveRandomly());
    }

    protected virtual void Update()
    {
        // 생존 시간 증가
        survivalTime += Time.deltaTime;

        // 번식 쿨다운 감소
        if (reproductionCooldown >= 0)
        {
            reproductionCooldown -= Time.deltaTime;
        }
        else
        {
            reproductionCooldown = 0;
        }

        // 생존 에너지 소모
        energy -= energyLossRate * Time.deltaTime;
        
        if (energy <= 0) Die();
        
        // 에너지 80% 이상일 때 번식
        if (energy >= maxEnergy * 0.8f && reproductionCooldown == 0) 
        {
            Reproduce();
            reproductionCooldown = 10f; // 번식 후 쿨다운 초기화
        }
    }

    protected void Wander()
    {
        if (rb == null) return;

        rb.linearVelocity = randomDir * speed;
        
        if (Random.value < 0.01f) 
        {
            transform.Rotate(0, 0, Random.Range(-45f, 45f));
        }
    }

    IEnumerator MoveRandomly()
    {
        while (true)
        {
            randomDir = new Vector2(Random.Range(-1f, 1), Random.Range(-1f, 1)).normalized;
            rb.linearVelocity = randomDir * speed;
            yield return new WaitForSeconds(Random.Range(5f, 15f));
        }
    }

    // 먹이 찾기 알고리즘 (T는 추적할 대상의 클래스 이름)
    protected void FindAndEat<T>() where T : Component
    {
        if (rb == null) return;

        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, detectionRange);
        Transform closestTarget = null;
        float minDistance = Mathf.Infinity;

        foreach (var col in targets)
        {
            T targetComponent = col.GetComponent<T>();
            if (targetComponent != null && col.gameObject != this.gameObject)
            {
                float dist = Vector2.Distance(transform.position, col.transform.position);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    closestTarget = col.transform;
                }
            }
        }

        if (closestTarget != null && survivalTime > 2f)
        {
            Vector2 direction = (closestTarget.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
            
            // 먹이와 닿으면 에너지 흡수 및 먹이 파괴 및 시체 생성
            if (minDistance < 0.5f)
            {
                energy += 30f; 
                if (energy > maxEnergy) energy = maxEnergy;

                // 살아있는 것을 먹으면 사체 남김, 사체 먹으면 사체 안 남김
                if (closestTarget.GetComponent<diedBug>() != null)
                {
                    Destroy(closestTarget.gameObject);
                }
                else
                {
                    Destroy(closestTarget.gameObject);
                    Instantiate(Resources.Load<GameObject>("04.Prefabs/사체"), transform.position, Quaternion.identity);
                }
                
            }
        }
        else
        {
            Wander();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected abstract void Reproduce();
}