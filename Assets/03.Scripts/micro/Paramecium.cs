using UnityEngine;

public class Paramecium : MicrobeBase
{
    protected override void Update()
    {
        base.Update();
        // 유글레나(생산자)를 찾아 먹음
        FindAndEat<Euglena>();
    }

    protected override void Reproduce()
    {
        energy /= 2;
        Instantiate(gameObject, transform.position + (Vector3)Random.insideUnitCircle, Quaternion.identity);
    }
}