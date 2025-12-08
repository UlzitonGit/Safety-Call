using System.Collections.Generic;
using UnityEngine;

public class HostagesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _hostages;

    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private int[] _hostagesInLocationRandomize;

   


    private void Start()
    {
        if (_hostagesInLocationRandomize[1] >= _hostages.Length) _hostagesInLocationRandomize[1] = _hostages.Length;

        int enemiesCount = Random.Range(_hostagesInLocationRandomize[0], _hostagesInLocationRandomize[1]);

        for (int i = 0; i < enemiesCount; i++)
        {
            int currentSpawn = Random.Range(0, _spawnPoints.Length);


            _hostages[i].SetActive(true);
            _hostages[i].transform.position = _spawnPoints[currentSpawn].position;

        }
    }
}