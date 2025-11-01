using Source.Creatures.Movement;
using UnityEngine;

public class EnemyMovement : CreatureMovement
{
    private bool _isTargeted = false;
    protected void FixedUpdate()
    {
        LookAtPosition();
    }

    public override void LookAtTarget(Vector3 target)
    {
        base.LookAtTarget(target);
        _isTargeted = true;
    }

    protected override void LookAtPosition()
    {
        if(!_isTargeted) return;
        base.LookAtPosition();
    }
    
}
