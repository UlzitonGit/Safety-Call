using UnityEngine;

public class EnemyStates : CreatureStates
{
    [SerializeField] private EnemyData _enemyData;
    
    public override void SetAlive(bool alive)
    {
        base.SetAlive(alive);
        _enemyData._FieldOfView.SetIsAbleToSee(alive);
        _enemyData._playerGunfight.SetIsAbleToShoot(alive);
    }
}
