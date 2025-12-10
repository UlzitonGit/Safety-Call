using System.Collections.Generic;
using UnityEngine;

public class HostagesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _hostagesPrefabs;

    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private int[] _hostagesInLocationRandomize;

   


    private void Start()
    {

        int enemiesCount = Random.Range(_hostagesInLocationRandomize[0], _hostagesInLocationRandomize[1]);

        for (int i = 0; i < enemiesCount; i++)
        {
            int currentSpawn = Random.Range(0, _spawnPoints.Length);
            Instantiate(_hostagesPrefabs[Random.Range(0, _hostagesPrefabs.Length)], _spawnPoints[currentSpawn].position, Quaternion.identity);
        }
    }
}