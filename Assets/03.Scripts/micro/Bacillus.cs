using UnityEngine;

public class Bacillus : MicrobeBase
{
    protected override void Update()
    {
        base.Update();
        FindAndEat<diedBug>();
    }

    protected override void Reproduce()
    {
        energy /= 2;
        Instantiate(gameObject, transform.position + (Vector3)Random.insideUnitCircle, Quaternion.identity);
    }
}