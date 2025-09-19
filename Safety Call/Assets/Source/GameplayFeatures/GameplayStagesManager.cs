using System;
using Source.Enemy;
using UnityEngine;

public class GameplayStagesManager : MonoBehaviour
{
    [SerializeField] private GameObject _winEndPanel;
    [SerializeField] private GameObject _looseEndPanel;
    private int _playersCount;
    private int _enemyCount;

    private void Start()
    {
        _enemyCount = FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None).Length;
        _playersCount = FindObjectsByType<PlayerHealth>(FindObjectsSortMode.None).Length;
    }

    public void EnemyKilled()
    {
        _enemyCount -= 1;
        if (_enemyCount == 0)
        {
            _winEndPanel.SetActive(true);
        }
    }

    public void PlayerKilled()
    {
        _playersCount -= 1;
        if (_playersCount == 0)
        {
            _looseEndPanel.SetActive(true);
        }
    }
}
