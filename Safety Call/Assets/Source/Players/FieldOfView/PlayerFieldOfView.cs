using System;
using Source.Players.Behaviour;
using UnityEngine;

public class PlayerFieldOfView : FieldOfView
{
    [SerializeField] private GunfightBehaviourManager _playerGunfightBehaviourManager;
    
    protected void Start()
    {
        _isAbleToSee = true;
    }
    private void FixedUpdate()
    {
        FindVisibleTargets();
    }

    protected override void ActionViewedObject(Transform target)
    {
       // if(_playerGunfightBehaviourManager.IsHasTarget()) return;
        EnemyVisibility enemy = target.GetComponent<EnemyVisibility>();
        print(enemy);
        enemy.ShowEnemy();
        _playerGunfightBehaviourManager.AddEnemyTarget(enemy.GetComponent<CreatureStates>());
    }
    
}
