using Assets.Scripts.Race;
using System.Collections;
using UnityEngine;

public class CarData : MonoBehaviour, IRaceData
{
    [SerializeField] private RaceState raceState;
    [SerializeField] private float fastTime;//время
    [SerializeField] private int lap;//круг
    private void OnEnable()
    {
        RaceController.ChangeState += StartRace;
    }
    private void OnDisable()
    {
        RaceController.ChangeState -= StartRace;
    }
    private void StartRace(RaceState raceState)//запуск счетчика
    {
        this.raceState = raceState;
        if (raceState == RaceState.Race)
            StartCoroutine(StartTimeCount());
    }
    private IEnumerator StartTimeCount()//счетчик времени
    {
        while(raceState == RaceState.Race)
        {
            yield return null;
            fastTime += Time.deltaTime;
        }
    }
    public int GetLap()//получение круга
    {
        lap++;
        return lap;
    }
    public float GetFastTime()//получение времени круга
    {
        float temp = fastTime;
        fastTime = 0;
        return temp;
    }
}
