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
        IPlayerSpotable enemy = target.GetComponent<IPlayerSpotable>();
        print(enemy);
        enemy.ShowEnemy();
        if(target.TryGetComponent<EnemyStates>(out var creature))
            _playerGunfightBehaviourManager.AddEnemyTarget(creature);
    }
    
}
