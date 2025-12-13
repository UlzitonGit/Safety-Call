using Source.Creatures.Movement;
using UnityEngine;

public class StrategyChangePosition : IEnemyActionStrategy
{
    public void PerformStrategy(CreatureMovement creature, Vector3 target)
    {
        creature.MoveOnTarget(target);
        creature.LookAtTarget(target);
    }
}
