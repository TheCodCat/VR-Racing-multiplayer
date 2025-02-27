using Assets.Scripts.Race;
using System;
using System.Collections;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public static Action<RaceState> ChangeState;
    public static RaceController Instance;//singletone
    [SerializeField] private AudioClip clip;
    [SerializeField] private RaceState raceState;
    [SerializeField] private int playerCount;
    public RaceState RaceState
    {
        get
        {
            return raceState;
        }
        set
        {
            raceState = value;
            ChangeState?.Invoke(value);
        }
    }
    public float FastTime = float.MaxValue;
    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        SpayerSpawner.OnJoined += StartRace;
    }
    private void OnDisable()
    {
        SpayerSpawner.OnJoined -= StartRace;
    }
    public void StartRace(int count)
    {
        if (count.Equals(playerCount))
            StartCoroutine(Downcounter());
    }
    private IEnumerator Downcounter()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("Áèï");
            AudioSource.PlayClipAtPoint(clip,transform.position, 0.5f);
        }
        RaceState = RaceState.Race;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out IRaceData component))
        {
            float time = component.GetFastTime();
            if (time < FastTime)
            {
                FastTime = time;
            }
            if (component.GetLap().Equals(3))
            {
                RaceState = RaceState.Finish;
            }
        }
    }
}
