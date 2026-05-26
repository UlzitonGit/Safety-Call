using Source.Creatures.Movement;
using UnityEngine;

public class EnemyMovement : CreatureMovement
{
    private bool _isTargeted = false;
    protected void FixedUpdate()
    {
        LookAtPosition();
        if (_aimPoint.transform.localEulerAngles.z > 0 && _aimPoint.transform.localEulerAngles.z > 180)
        {
            _aimPoint.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            _aimPoint.localScale = new Vector3(-1, 1, 1);
        }
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
