using UnityEngine;

public class Euglena : MicrobeBase
{
    [Header("Euglena Settings")]
    public bool isLightAvailable = true; // 환경 매니저에서 조절 가능

    protected override void Update()
    {
        base.Update(); // 에너지 소모 및 사멸 로직 실행

        if (isLightAvailable)
        {
            // 광합성 모드: 이동하며 에너지 충전
            energy += 3f * Time.deltaTime; 
            Wander();
        }
        else
        {
            // 어두우면 유기물 탐색 (OrganicMatter 클래스가 있다고 가정)
            // FindAndEat<OrganicMatter>(); 
            Wander();
        }
    }

    protected override void Reproduce()
    {
        energy /= 2;
        Instantiate(gameObject, transform.position + (Vector3)Random.insideUnitCircle, Quaternion.identity);
    }
}