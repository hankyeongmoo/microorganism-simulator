using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    public GameObject[] bugs;
    [SerializeField] private bool resetSign = false; // 버튼으로 변수가 바뀜

    void Start()
    {
        SimulStart();
    }

    void SpawnBug(int count, int bugType) // bugType: 0-생산자, 1-1차 소비자, 2-2차 소비자, 3-분해자
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(bugs[bugType], new Vector3(Random.Range(-49, 49), Random.Range(-39, 39), 0), Quaternion.identity);
        }
    }

    public void SimulStart()
    {
        SpawnBug(20, 0);
        SpawnBug(5, 1);
        SpawnBug(3, 2);
        SpawnBug(10, 3);
    }

    // 버튼으로 시뮬레이터 초기화
    public void ResetSimulation()
    {
        resetSign = true;

        StartCoroutine(ResetCRT());
    }

    IEnumerator ResetCRT()
    {
        yield return null;
        if (resetSign)
        {
            resetSign = false;
            SimulStart();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (resetSign)
        {
            resetSign = false;
            // 씬의 모든 미생물 제거
            foreach (var microbe in GameObject.FindGameObjectsWithTag("0"))
                Destroy(microbe);
            foreach (var microbe in GameObject.FindGameObjectsWithTag("1"))
                Destroy(microbe);
            foreach (var microbe in GameObject.FindGameObjectsWithTag("2"))
                Destroy(microbe);
            foreach (var microbe in GameObject.FindGameObjectsWithTag("3"))
                Destroy(microbe);
            foreach (var microbe in GameObject.FindGameObjectsWithTag("diedBug"))
                Destroy(microbe);

            SimulStart();
        }
    }

    public void __Spawn_Englena()
    {
        SpawnBug(1, 0);
    }

    public void __Spawn_Paramecium()
    {
        SpawnBug(1, 1);
    }

    public void __Spawn_Didinium()
    {
        SpawnBug(1, 2);
    }

    public void __Spawn_Bacillus()
    {
        SpawnBug(1, 3);
    }
}
