using UnityEngine;

public class diedBug : MonoBehaviour
{
    private float existTime = 0f; // 죽은 벌레가 존재하는 시간

    // protected override void Start()
    // {
    //     existTime = 0f;
    // }

    // protected override void Update()
    // {
    //     existTime += Time.deltaTime;

    //     // 일정 시간이 지나면 시체 제거
    //     if (existTime >= 20f) Destroy(gameObject);
    // }

    // protected override void Reproduce()
    // {
    //     // 죽은 벌레는 번식하지 않음
    // }

    void Start()
    {
        existTime = 0f;
    }

    void Update()
    {
        existTime += Time.deltaTime;

        // 일정 시간이 지나면 시체 제거
        if (existTime >= 20f) Destroy(gameObject);
    }
}
