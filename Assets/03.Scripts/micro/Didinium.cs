using UnityEngine;

public class Didinium : MicrobeBase
{
    protected override void Start()
    {
        base.Start();
        // 2차 소비자는 더 빠르고 시야가 넓음
    }

    protected override void Update()
    {
        base.Update();
        // 짚신벌레(1차 소비자)를 찾아 먹음
        FindAndEat<Paramecium>();
    }

    protected override void Reproduce()
    {
        energy /= 2;
        Instantiate(gameObject, transform.position + (Vector3)Random.insideUnitCircle, Quaternion.identity);
    }
}