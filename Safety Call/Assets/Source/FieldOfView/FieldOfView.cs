using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class FieldOfView : MonoBehaviour
{
    public float viewRadius = 10;
    public float viewAngle;
    
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private LayerMask _obstacleLayerMask;

    protected virtual void FindVisibleTargets()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, viewRadius, _targetLayerMask);
        
        for (int i = 0; i < colliders.Length; i++)
        {
            Transform target = colliders[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector2.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                print(colliders.Length);
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, _obstacleLayerMask))
                {
                    print("Find");
                    ActionViewedObject(target);
                }
            }
        }
    }
    public virtual Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees -= transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }

    protected virtual void ActionViewedObject(Transform target)
    {
        //DoSmth
    }
}
