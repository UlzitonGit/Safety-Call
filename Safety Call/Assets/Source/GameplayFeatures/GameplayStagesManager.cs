using System;
using Source.Enemy;
using UnityEngine;

public class GameplayStagesManager : MonoBehaviour
{
    [SerializeField] private GameObject _winEndPanel;
    [SerializeField] private GameObject _looseEndPanel;
    [SerializeField] private CreaturesData[] _creaturesData;

    private int _hostagesCount;
    private int _playersCount;
    private int _enemyCount;

    private bool _enemiesKilled;
    private bool _hostagesRescu

    private void Start()
    {
        _enemyCount = FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None).Length;
        _playersCount = FindObjectsByType<PlayerHealth>(FindObjectsSortMode.None).Length;
        _hostagesCount = FindObjectsByType<HostagesHealth>(FindObjectsSortMode.None).Length;
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

        int dead = 0;
        foreach (var creature in _creaturesData)
        {
            if (creature._playerState.IsAlive == false)
            {
                dead++;
            }
        }

        if (dead == _playersCount)
        {
            _looseEndPanel.SetActive(true);
        }
    }

    private void HostageRescued()
    {
        _hostagesCount -= 1;
    }
}
