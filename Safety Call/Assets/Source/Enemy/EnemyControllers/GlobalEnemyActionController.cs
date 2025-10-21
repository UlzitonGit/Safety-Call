using System.Collections;
using System.Collections.Generic;
using Source.Creatures.Movement;
using UnityEngine;
using Random = UnityEngine.Random;

public class GlobalEnemyActionController: MonoBehaviour
{
    
    [SerializeField] EnemyInterestPoints _interestPoints;

    private List<EnemyMovement> _enemiesList;
    
    private EnemyStrategySetter _strategySetter;

    private void Awake()
    {
        _strategySetter = new EnemyStrategySetter();
        _strategySetter.InitializeSetter();
    }

    private void Start()
    {
        StartCoroutine(MoveRandomEnemy());
    }

    IEnumerator MoveRandomEnemy()
    {
        yield return new WaitForSeconds(Random.Range(5f, 10f));
        InitializeMovementToRandomPoint(_enemiesList[Random.Range(0, _enemiesList.Count)]);
        StartCoroutine(MoveRandomEnemy());
    }
    public void InitializeStartPoints(List<EnemyMovement> enemiesList)
    {
        _enemiesList = enemiesList;
        foreach (var enemy in _enemiesList)
        {
            print(_interestPoints.GetRandomPoint());
            _strategySetter.PerformStay(enemy, _interestPoints.GetRandomPoint());
        }
    }

    public void InitializeMovementToRandomPoint(CreatureMovement creature)
    {
        _strategySetter.PerformMovement(creature, _interestPoints.GetRandomPoint());
    }
}
