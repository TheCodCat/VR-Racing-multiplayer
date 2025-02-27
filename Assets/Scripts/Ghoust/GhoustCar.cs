using Assets.Scripts.Race;
using UnityEngine;
using UnityEngine.AI;

public class GhoustCar : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;//�����
    [SerializeField] private RaceState raceState;//���������
    [SerializeField] private int index;//������ �����
    [SerializeField] private Transform[] points;//����� ��������
    private void OnEnable()
    {
        RaceController.ChangeState += StartRace;
    }
    private void OnDisable()
    {
        RaceController.ChangeState -= StartRace;
    }
    private void StartRace(RaceState raceState)//����� ���������
    {
        this.raceState = raceState;
    }
    private void Update()//�������� ������
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
