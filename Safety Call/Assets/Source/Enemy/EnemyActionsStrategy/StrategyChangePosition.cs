using Source.Creatures.Movement;
using UnityEngine;

public class StrategyChangePosition : IEnemyActionStrategy
{
    public void PerformStrategy(CreatureMovement creature, Transform target)
    {
        creature.MoveOnTarget(target.position);
        creature.LookAtTarget(target.position);
    }
}
