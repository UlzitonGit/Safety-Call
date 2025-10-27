using System;
using System.Collections;
using Source.Players.Behaviour;
using UnityEngine;

public class EnemyFieldOfView : FieldOfView
{
    [SerializeField] private GunfightBehaviourManager _enemyGunfightBehaviourManager;

    [SerializeField] private EnemyVisibility _enemyVisibility;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void FixedUpdate()
    {
        FindVisibleTargets();
    }

    protected override void ActionViewedObject(Transform target)
    {
        PlayerData player = target.GetComponent<PlayerData>();
        print(player.transform.name);
        player._playerState.SetVisible(true);
        _enemyVisibility.ShowEnemy();
        _enemyGunfightBehaviourManager.AddEnemyTarget(player._playerState);
    }
}
