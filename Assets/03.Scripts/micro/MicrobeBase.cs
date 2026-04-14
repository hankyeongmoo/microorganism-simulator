using UnityEngine;

public abstract class MicrobeBase : MonoBehaviour
{
    [Header("Base Stats")]
    public float energy = 50f;
    public float maxEnergy = 100f;
    public float speed = 2f;
    public float detectionRange = 5f;
    public float energyLossRate = 1f;

    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError($"{gameObject.name}에 Rigidbody2D가 없습니다! 컴포넌트를 추가해주세요.");
        }
    }

    protected virtual void Update()
    {
        // 생존 에너지 소모
        energy -= energyLossRate * Time.deltaTime;
        
        if (energy <= 0) Die();
        
        // 에너지 80% 이상일 때 번식
        if (energy >= maxEnergy * 0.8f) 
        {
            Reproduce();
        }
    }

    protected void Wander()
    {
        if (rb == null) return;

        rb.linearVelocity = transform.up * speed;
        
        if (Random.value < 0.01f) 
        {
            transform.Rotate(0, 0, Random.Range(-45f, 45f));
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

        if (closestTarget != null)
        {
            Vector2 direction = (closestTarget.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
            
            // 먹이와 닿으면 에너지 흡수 및 먹이 파괴
            if (minDistance < 0.5f)
            {
                energy += 30f; 
                if (energy > maxEnergy) energy = maxEnergy;
                Destroy(closestTarget.gameObject);
            }
        }
        else
        {
            Wander();
        }
    }

    protected virtual void Die()
    {
        // 사멸 시 유기물을 남기는 로직 등을 여기 추가할 수 있습니다.
        Destroy(gameObject);
    }

    protected abstract void Reproduce();
}