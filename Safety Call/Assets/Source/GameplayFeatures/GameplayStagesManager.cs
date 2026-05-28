using System;
using Source.Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayStagesManager : MonoBehaviour
{
    
    public int AllHostages;
    public int AllEnemies;
    [SerializeField] private int levelIndex;
    [SerializeField] private GameObject _winEndPanel;
    [SerializeField] private GameObject _looseEndPanel;
    [SerializeField] private CreaturesData[] _creaturesData;
    
    [SerializeField] PlayerUiDrawer _playerUiDrawer;
    private int _hostagesCount;
    private int _playersCount = 4;
    private int _enemyCount;

    private bool _enemiesKilled;
    private bool _hostagesRescued;

    private int _maxScore;
    private int _score;
    
    public ObservableValue<float> Percents { get; set; }
    public ObservableValue<int> Hostages { get; set; }
    public ObservableValue<int> Enemies { get; set; }
    private void Start()
    {
        if (!_playerUiDrawer.gameObject.activeInHierarchy)
        {
            _playerUiDrawer.gameObject.SetActive(true);
        }
        Percents = new ObservableValue<float>(0);
        Hostages = new ObservableValue<int>(0);
        Enemies = new ObservableValue<int>(0);

        _playerUiDrawer.InitializeState(this);
    }

    public void EnemyCount(int count)
    {
        AllEnemies = count;
    }

    public void HostagesCount(int count)
    {
        AllHostages = count;
    }
    
    
    public void EnemyKilled()
    {
        _enemyCount += 1;
        _score += 50;
        if (_enemyCount == AllEnemies)
        {
            _enemiesKilled = true;
        }

        Enemies.Value = _enemyCount;
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
        _hostagesCount += 1;
        _score += 100;
        Hostages.Value = _hostagesCount;
        if (_hostagesCount == AllHostages)
        {
            _hostagesRescued = true;
        }
        CheckMissionIsEnded();
    }

    private void CheckMissionIsEnded()
    {
        
        Percents.Value = CalculatePercents();
        if (_hostagesRescued && _enemiesKilled)
        {
            _maxScore = _enemyCount * 50 + _playersCount * 200 + _hostagesCount * 100;
            _score = _playersCount * 200;
            //int maxLevel = PlayerPrefs.GetInt("MaxLevel");
            //if (maxLevel < levelIndex)
            //{
            PlayerPrefs.SetInt("MaxLevel", levelIndex);
            //}
            _winEndPanel.SetActive(true);
        }
    }

    private float CalculatePercents()
    {
        int totalObjectives = AllEnemies + AllHostages;
        
        
        int completedObjectives = _enemyCount + _hostagesCount;
        
        float progress = (float)completedObjectives / totalObjectives * 100f;
        int roundedProgress = Mathf.RoundToInt(progress);
        
        return Mathf.Min(roundedProgress, 100);
    }
}
