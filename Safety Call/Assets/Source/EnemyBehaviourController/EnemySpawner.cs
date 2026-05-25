using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemiesPrefabs;
    
    [SerializeField] private GameplayStagesManager _gameplayStagesManager;
    
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private int[] _enemiesInLocationRandomize;
    
    [SerializeField] private GlobalEnemyActionController _actionController;

    [SerializeField] private PlayerLoadoutSO[] _loadouts;
    
    private List<EnemyData> _enemies = new List<EnemyData>();

    private List<EnemyMovement> _enemyMovements = new List<EnemyMovement>();
    
    [SerializeField] bool spawn = true;
    private void Start()
    {
        if (spawn)
        {
            int enemiesCount = Random.Range(_enemiesInLocationRandomize[0], _enemiesInLocationRandomize[1]);
            for (int i = 0; i < enemiesCount; i++)
            {
                int currentSpawn = Random.Range(0, _spawnPoints.Length);
                _enemies.Add(Instantiate(_enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Length)],
                    _spawnPoints[currentSpawn].position, Quaternion.identity).GetComponent<EnemyData>());
            }
            
        }
        EnemyData[] enemyDatas = FindObjectsByType<EnemyData>(FindObjectsSortMode.None);
        
        foreach (var enemy in enemyDatas)
        {
            _enemyMovements.Add(enemy._enemyMovement);
            enemy._SoReader.SetWeapon(_loadouts[Random.Range(0, _loadouts.Length - 1)]);
            enemy._enemyHealth.SetActionController(_actionController);
        }
        _gameplayStagesManager.EnemyCount(enemyDatas.Length);
        _actionController.InitializeStartPoints(_enemyMovements);
    }
}
