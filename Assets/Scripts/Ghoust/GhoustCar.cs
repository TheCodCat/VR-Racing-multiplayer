using Assets.Scripts.Race;
using UnityEngine;
using UnityEngine.AI;

public class GhoustCar : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;//агент
    [SerializeField] private RaceState raceState;//состояние
    [SerializeField] private int index;//индекс точки
    [SerializeField] private Transform[] points;//точки движения
    private void OnEnable()
    {
        RaceController.ChangeState += StartRace;
    }
    private void OnDisable()
    {
        RaceController.ChangeState -= StartRace;
    }
    private void StartRace(RaceState raceState)//смена состояния
    {
        this.raceState = raceState;
    }
    private void Update()//движение агента
    {
        if(raceState == RaceState.Race)
        {
            if(agent.remainingDistance <= 1)
            {
                index = (index + 1) % points.Length;
                agent.SetDestination(points[index].position);
            }
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }
}
