using System;
using Global;
using UnityEngine;

public class LewelMap : MonoBehaviour
{
    public event Action<FinishPanel, PlayerStats> Finished; 
    private SpawnPositionsCoints _spawnPositionsCoints;
    private PlayerPosition _playerPosition;

    private void Awake()
    {
        _playerPosition = GetComponentInChildren<PlayerPosition>();
        _spawnPositionsCoints = GetComponentInChildren<SpawnPositionsCoints>();
    }

    public void Init(FinishPanel finishPanel, PlayerStats playerStats) => Finished?.Invoke(finishPanel, playerStats); 
    
    public Vector3 GetSpawnPlayerPosition() => _playerPosition.PlayerPositionSpawn.position;
    
    public Transform[] GetPositionSpawn() => _spawnPositionsCoints.GetPositions();
}
