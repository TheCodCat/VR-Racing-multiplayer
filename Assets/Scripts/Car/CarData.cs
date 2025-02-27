using Assets.Scripts.Race;
using System.Collections;
using UnityEngine;

public class CarData : MonoBehaviour, IRaceData
{
    [SerializeField] private RaceState raceState;
    [SerializeField] private float fastTime;//�����
    [SerializeField] private int lap;//����
    private void OnEnable()
    {
        RaceController.ChangeState += StartRace;
    }
    private void OnDisable()
    {
        RaceController.ChangeState -= StartRace;
    }
    private void StartRace(RaceState raceState)//������ ��������
    {
        this.raceState = raceState;
        if (raceState == RaceState.Race)
            StartCoroutine(StartTimeCount());
    }
    private IEnumerator StartTimeCount()//������� �������
    {
        while(raceState == RaceState.Race)
        {
            yield return null;
            fastTime += Time.deltaTime;
        }
    }
    public int GetLap()//��������� �����
    {
        lap++;
        return lap;
    }
    public float GetFastTime()//��������� ������� �����
    {
        float temp = fastTime;
        fastTime = 0;
        return temp;
    }
}
