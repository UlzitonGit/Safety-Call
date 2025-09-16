using System;
using UnityEngine;
using UnityEngine.AI;

public class LinePathController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    
    private LineRenderer _pathLine;

    private void Start()
    {
        _pathLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (_agent.hasPath)
        {
            UpdateLineRenderer(_agent.path);
        }
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
