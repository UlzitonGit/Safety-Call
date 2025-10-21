using Source.Creatures.Movement;
using UnityEngine;

public class StrategyStayAndLook : IEnemyActionStrategy
{
    public void PerformStrategy(CreatureMovement creature, Transform target)
    {
        Debug.Log(target);
        creature.LookAtTarget(target.position);
    }
}
