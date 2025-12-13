using Source.Creatures.Movement;
using UnityEngine;

public class StrategyStayAndLook : IEnemyActionStrategy
{
    public void PerformStrategy(CreatureMovement creature, Vector3 target)
    {
        Debug.Log(target);
        creature.LookAtTarget(target);
    }
}
