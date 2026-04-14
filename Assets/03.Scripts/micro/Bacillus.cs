using UnityEngine;

public class Bacillus : MicrobeBase
{
    protected override void Update()
    {
        base.Update();
        // 시체나 유기물을 찾는 로직 (기획에 따라 추가)
        Wander();
    }

    protected override void Reproduce()
    {
        energy /= 2;
        Instantiate(gameObject, transform.position + (Vector3)Random.insideUnitCircle, Quaternion.identity);
    }
}