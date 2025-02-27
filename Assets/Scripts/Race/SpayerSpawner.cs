using UnityEngine;
using Fusion;
using System.Linq;
using System;

public class SpayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public static Action<int> OnJoined;
    [SerializeField] private NetworkObject prefab;//префаб игрока
    [SerializeField] private Transform[] spawnPoints;//точки спавна
    public void PlayerJoined(PlayerRef player)//спавн игрока
    {
        if(player == Runner.LocalPlayer)
        {
            int index = Runner.ActivePlayers.Count() == 1 ? 0: 1;
            Runner.Spawn(prefab, spawnPoints[index].position, spawnPoints[index].localRotation);
        }
        OnJoined?.Invoke(Runner.ActivePlayers.Count());
    }
}
