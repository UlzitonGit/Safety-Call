using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : CreatureMovement
{
    [SerializeField] private LineRenderer _pathLine;
    
    private void FixedUpdate()
    {
        if (_agent.hasPath)
        {
            UpdateLineRenderer(_agent.path);
        }
    }

    public override void MoveOnTarget(Vector3 target)
    {
        base.MoveOnTarget(target);
    }
    void UpdateLineRenderer(NavMeshPath path)
    {
        if (path.corners.Length < 2)
        {
            _pathLine.positionCount = 0;
            return;
        }
        
        _pathLine.positionCount = path.corners.Length;
        
        for (int i = 0; i < path.corners.Length; i++)
        {
            Vector3 pointPosition = path.corners[i] + Vector3.up;
            _pathLine.SetPosition(i, pointPosition);
        }
    }
}
