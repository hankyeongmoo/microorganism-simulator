using UnityEngine;

public class Didinium : MicrobeBase
{
    protected override void Start()
    {
        base.Start();
        // 2차 소비자는 더 빠르고 시야가 넓음
        speed *= 1.5f;
        detectionRange *= 1.5f;
    }

    protected override void Update()
    {
        base.Update();
        // 짚신벌레(1차 소비자)를 찾아 먹음
        FindAndEat<Paramecium>();
    }

    protected override void Reproduce()
    {
        // 2차 소비자는 번식이 느림 (에너지가 더 많이 필요함)
        if (energy >= maxEnergy * 0.95f)
        {
            energy /= 2;
            Instantiate(gameObject, transform.position + (Vector3)Random.insideUnitCircle, Quaternion.identity);
        }
    }
}