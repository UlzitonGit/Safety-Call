using System;
using Source.Players.Behaviour;
using UnityEngine;

public class PlayerFieldOfView : FieldOfView
{
    [SerializeField] private GunfightBehaviourManager _playerGunfightBehaviourManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        viewAngle = 60;
        viewRadius = 10;
    }

    private void FixedUpdate()
    {
        FindVisibleTargets();
    }

    protected override void ActionViewedObject(Transform target)
    {
        EnemyVisibility enemy = target.GetComponent<EnemyVisibility>();
        enemy.ShowEnemy();
        _playerGunfightBehaviourManager.AddEnemyTarget(enemy.GetComponent<CreatureStates>());
    }
    
}
