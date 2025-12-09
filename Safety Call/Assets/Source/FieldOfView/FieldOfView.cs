using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class FieldOfView : MonoBehaviour
{
    [SerializeField] protected float _viewRadius = 10; 
    [SerializeField] protected float _viewAngle;
    
    [SerializeField] protected LayerMask _targetLayerMask;
    [SerializeField] protected LayerMask _obstacleLayerMask;

    protected bool _isAbleToSee = true;
    
    protected void Start()
    {
        _isAbleToSee = true;
    }
    protected virtual void FindVisibleTargets()
    {
        if(_isAbleToSee == false) return;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _viewRadius, _targetLayerMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            Transform target = colliders[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            float dstToTarget = Vector3.Distance(transform.position, target.position);
            if (dstToTarget < 3)
            {
                if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, _obstacleLayerMask))
                {
                    ActionViewedObject(target);
                }
            }
            else if (Vector2.Angle(transform.up, dirToTarget) < _viewAngle / 2)
            {
                if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, _obstacleLayerMask))
                {
                    ActionViewedObject(target);
                }
            }
            
        }
    }

    public void SetIsAbleToSee(bool isAbleToSee)
    {
        _isAbleToSee = isAbleToSee;
    }

    public float GetViewRadius()
    {
        return _viewRadius;
    }

    public float GetViewAngle()
    {
        return _viewAngle;
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
