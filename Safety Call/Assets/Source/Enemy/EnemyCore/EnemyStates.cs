using UnityEngine;

public class EnemyStates : CreatureStates
{
    [SerializeField] private EnemyData _enemyData;
    
    public override void SetAlive(bool alive)
    {
        base.SetAlive(alive);
        if(_enemyData._FieldOfView != null)  _enemyData._FieldOfView.SetIsAbleToSee(alive);
        if(_enemyData._playerGunfight != null)  _enemyData._playerGunfight.SetIsAbleToShoot(alive);
    }
}
