using UnityEngine;
using System.Collections.Generic;

public class DataTracker : MonoBehaviour
{
    public List<int> producers = new List<int>();
    public List<int> primary = new List<int>();
    public List<int> secondary = new List<int>();
    public List<int> decomposers = new List<int>();

    public float recordInterval = 1f;

    void Start()
    {
        InvokeRepeating("RecordData", 0f, recordInterval);
    }

    void RecordData()
    {
        producers.Add(GameObject.FindGameObjectsWithTag("0").Length);
        primary.Add(GameObject.FindGameObjectsWithTag("1").Length);
        secondary.Add(GameObject.FindGameObjectsWithTag("2").Length);
        decomposers.Add(GameObject.FindGameObjectsWithTag("3").Length);
    }

    // CSV 저장 (보고서용)
    public void SaveToCSV()
    {
        string path = Application.dataPath + "/ecosystem_data.csv";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.AppendLine("Time,Producer,Primary,Secondary,Decomposer");

        for (int i = 0; i < producers.Count; i++)
        {
            sb.AppendLine(i + "," + producers[i] + "," + primary[i] + "," + secondary[i] + "," + decomposers[i]);
        }

        System.IO.File.WriteAllText(path, sb.ToString());
        Debug.Log("CSV 저장 완료: " + path);
    }

    // 데이터 초기화 & 기록 재시작 & 파일 저장 (버튼 클릭 시)
    public void ___ClickButton()
    {
        // 기록 중지 (가장 먼저)
        CancelInvoke("RecordData");

        // CSV 저장
        SaveToCSV();

        // 데이터 초기화
        producers.Clear();
        primary.Clear();
        secondary.Clear();
        decomposers.Clear();

        // 초기 상태 즉시 기록 (시간 0초)
        RecordData();

        // 반복 기록 재시작 (다음 시간부터)
        InvokeRepeating("RecordData", recordInterval, recordInterval);
    }
}