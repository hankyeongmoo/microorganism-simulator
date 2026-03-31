using UnityEngine;

public class MoveBug : MonoBehaviour
{
    [Header("버그 속성")]
    public short bugType; // 0: 생산자, 1: 1차 소비자, 2: 2차 소비자, 3: 분해자

    [Header("물리 및 상태 변수")]
    public float energy;
    public int age;

    [Header("유전적 형질 변수")]
    public float speed;
    public float detectionRange;
    public float metabolicRate;
    public float mutationRate;

    [Header("행동 및 인지 변수")]
    public string state; // 배회, 추적, 도망, 번식, 휴식
    public float HungerThreshold;
    public float ReproductionThreshold;

    [Header("환경 상호작용 변수")]
    public float temperatureTolerance;
    public int dietaryPreference; // 0: 생산자, 1: 1차 소비자, 2: 2차 소비자, 3: 분해자

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
