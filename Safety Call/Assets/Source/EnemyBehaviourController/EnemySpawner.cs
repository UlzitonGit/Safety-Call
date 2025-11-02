using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private int[] _enemiesInLocationRandomize;
    
    [SerializeField] private GlobalEnemyActionController _actionController;

    [SerializeField] private PlayerLoadoutSO[] _loadouts;
    
    private List<int>  busySpawns = new List<int>();

    private List<EnemyMovement> _enemyMovements = new List<EnemyMovement>();
    

    private void Start()
    {
        if(_enemiesInLocationRandomize[1] >= _enemies.Length) _enemiesInLocationRandomize[1] = _enemies.Length;
        
        int enemiesCount = Random.Range(_enemiesInLocationRandomize[0], _enemiesInLocationRandomize[1]);
        foreach (var enemy in _enemies)
        {
            _enemyMovements.Add(enemy.GetComponent<EnemyMovement>());
            enemy.GetComponentInChildren<PlayerSOReader>().SetWeapon(_loadouts[Random.Range(0, _loadouts.Length  - 1)]);
        }
        
        for (int i = 0; i < _enemiesInLocationRandomize[0] - 1; i++)
        {
            int currentSpawn = Random.Range(0, _spawnPoints.Length);
            
            
            _enemies[i].SetActive(true);
            _enemies[i].transform.position = _spawnPoints[currentSpawn].position;
          
            busySpawns.Add(currentSpawn);
        }
        _actionController.InitializeStartPoints(_enemyMovements);
    }
}
