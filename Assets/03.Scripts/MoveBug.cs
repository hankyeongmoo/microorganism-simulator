using UnityEngine;

public class MoveBug : MonoBehaviour
{
    [Header("버그 속성")]
    public short bugType;                // 0: 생산자 / 1: 1차 소비자 / 2: 2차 소비자 / 3: 분해자
    public float moveSpeed;              // 이동 속도
    public float maxEnergy;              // 에너지 최대치
    public float energyGainRate;         // 에너지 획득율
    public float energyConsumptionRate;  // 에너지 소비율
    public float maxWaste;               // 노폐물 최대치
    public float wasteProductionRate;    // 노폐물 생산율
    public float maxDuplicateTime;       // 최대 복제 시간
    public float minDuplicateTime;       // 최소 복제 시간
    public float duplicateEnergy;        // 복제 에너지
    public float duplicateProbability;   // 복제 확률
    public float deathRateFromInfection; // 감염으로 인한 사망률

    [Header("버그 상태")]
    private float currentEnergy; // 현재 에너지
    private float currentWaste;  // 현재 노폐물
    private bool isinfected;     // 감염 여부

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
