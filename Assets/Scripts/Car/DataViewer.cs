using Assets.Scripts.Race;
using TMPro;
using UnityEngine;

public class DataViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text time;
    private void OnEnable()
    {
        RaceController.ChangeState += ActiveviewFastTime;
    }
    private void OnDisable()
    {
        RaceController.ChangeState -= ActiveviewFastTime;
    }
    private void ActiveviewFastTime(RaceState raceState)
    {
        if(raceState == RaceState.Finish)
        {
            time.text = $"Время самого быстрого круга: {RaceController.Instance.FastTime.ToString("F1")}/c.";
        }
    }
}
