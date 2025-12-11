using System;
using Source.Enemy;
using UnityEngine;

public class GameplayStagesManager : MonoBehaviour
{
    [SerializeField] private GameObject _winEndPanel;
    [SerializeField] private GameObject _looseEndPanel;
    [SerializeField] private CreaturesData[] _creaturesData;
    [SerializeField] private EndGamePanelUi _endGamePanel;
    
    [SerializeField] private GamePlayStatesUI _gamePlayStatesUI;

    [SerializeField] private bool _isTutorial;

    private int _hostagesCount;
    private int _playersCount;
    private int _enemyCount;

    private bool _enemiesKilled;
    private bool _hostagesRescued;

    private int _maxScore;
    private int _score;

    private void Start()
    {
        _enemyCount = FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None).Length;
        _playersCount = FindObjectsByType<PlayerHealth>(FindObjectsSortMode.None).Length;
        _hostagesCount = FindObjectsByType<HostagesHealth>(FindObjectsSortMode.None).Length;
        
        _maxScore = _enemyCount * 50 + _playersCount * 200 + _hostagesCount * 100;
        _score = _playersCount * 200;
    }

    public void EnemyKilled()
    {
        if(_isTutorial) return;
        _enemyCount -= 1;
        _score += 50;
        if (_enemyCount == 0)
        {
            _enemiesKilled = true;
            _gamePlayStatesUI.CloseTask(1);
        }
        CheckMissionIsEnded();
    }

    public void PlayerKilled()
    {

        int dead = 0;
        foreach (var creature in _creaturesData)
        {
            if (creature._playerState.IsAlive == false)
            {
                _score -= 200;
                dead++;
            }
        }

        if (dead == _playersCount)
        {
            _looseEndPanel.SetActive(true);
        }
    }

    public void HostageRescued()
    {
        if (_isTutorial) return;
        _hostagesCount -= 1;
        _score += 100;
        if (_hostagesCount == 0)
        {
            _gamePlayStatesUI.CloseTask(0);
            _hostagesRescued = true;
        }
        CheckMissionIsEnded();
    }

    private void CheckMissionIsEnded()
    {
        if (_hostagesRescued && _enemiesKilled)
        {
            _winEndPanel.SetActive(true);
            _endGamePanel.ShowResults(_score, _maxScore);
        }
    }
}
