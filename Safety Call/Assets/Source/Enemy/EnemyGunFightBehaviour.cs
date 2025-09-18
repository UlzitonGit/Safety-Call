using Source.Players.Behaviour;
using UnityEngine;

public class EnemyGunFightBehaviour : GunfightBehaviourManager
{
    [SerializeField] private bool _canShootFirst;
    protected override bool CheckShootingRelevation()
    {
        return _canShootFirst;
    }

    public override void AddEnemyTarget(CreatureStates enemy)
    {
        base.AddEnemyTarget(enemy);
    }
}
