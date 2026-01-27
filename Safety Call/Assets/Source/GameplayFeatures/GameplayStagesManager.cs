using System;
using Source.Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayStagesManager : MonoBehaviour
{
    [SerializeField] private GameObject _winEndPanel;
    [SerializeField] private GameObject _looseEndPanel;
    [SerializeField] private CreaturesData[] _creaturesData;
    [SerializeField] private EndGamePanelUi _endGamePanel;
    
    [SerializeField] private GamePlayStatesUI _gamePlayStatesUI;

    private int _hostagesCount;
    private int _playersCount = 4;
    private int _enemyCount;

    private bool _enemiesKilled;
    private bool _hostagesRescued;

    private int _maxScore;
    private int _score;

    public void EnemyCount(int count)
    {
        _enemyCount = count;
    }

    public void HostagesCount(int count)
    {
        _hostagesCount = count;
    }
    
    
    public void EnemyKilled()
    {
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
            _maxScore = _enemyCount * 50 + _playersCount * 200 + _hostagesCount * 100;
            _score = _playersCount * 200;
            _winEndPanel.SetActive(true);
            _endGamePanel.ShowResults(_score, _maxScore);
        }
    }
}
