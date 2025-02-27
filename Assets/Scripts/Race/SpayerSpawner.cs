using UnityEngine;
using Fusion;
using System.Linq;
using System;

public class SpayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public static Action<int> OnJoined;
    [SerializeField] private NetworkObject prefab;//������ ������
    [SerializeField] private Transform[] spawnPoints;//����� ������
    public void PlayerJoined(PlayerRef player)//����� ������
    {
        if(player == Runner.LocalPlayer)
        {
            int index = Runner.ActivePlayers.Count() == 1 ? 0: 1;
            Runner.Spawn(prefab, spawnPoints[index].position, spawnPoints[index].localRotation);
        }
        OnJoined?.Invoke(Runner.ActivePlayers.Count());
    }
}
