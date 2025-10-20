using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private int[] _enemiesInLocationRandomize;
    
    private List<int>  busySpawns = new List<int>();
    

    private void Start()
    {
        if(_enemiesInLocationRandomize[1] >= _enemies.Length) _enemiesInLocationRandomize[1] = _enemies.Length;
        
        int enemiesCount = Random.Range(_enemiesInLocationRandomize[0], _enemiesInLocationRandomize[1]);
        
        for (int i = 0; i < _enemiesInLocationRandomize[0] - 1; i++)
        {
            int currentSpawn = Random.Range(0, _spawnPoints.Length);
            
          
            
            _enemies[i].SetActive(true);
            _enemies[i].transform.position = _spawnPoints[currentSpawn].position;
            _enemies[i].GetComponent<EnemyMovement>().LookAtTarget(_spawnPoints[Random.Range(0, _spawnPoints.Length)].position);
            busySpawns.Add(currentSpawn);
        }
    }
}
