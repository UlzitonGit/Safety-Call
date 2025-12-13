using System;
using Source.Creatures.Movement;
using UnityEngine;

public class EnemyStrategySetter
{
    private IEnemyActionStrategy _stayStrategy;
    private IEnemyActionStrategy _moveStrategy;

    public void InitializeSetter()
    {
        _moveStrategy = new StrategyChangePosition();
        _stayStrategy = new StrategyStayAndLook();
    }

    public void PerformMovement(CreatureMovement creature, Vector3 target)
    {
        //Debug.Log(creature + " : " + target.name);
        _moveStrategy.PerformStrategy(creature, target);
    }
    public void PerformStay(CreatureMovement creature, Vector3 target)
    {
        _stayStrategy.PerformStrategy(creature, target);
    }
}
