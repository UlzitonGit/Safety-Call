using System;
using UnityEngine;

public class PlayerFieldOfView : FieldOfView
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        viewAngle = 60;
        viewRadius = 10;
    }

    private void FixedUpdate()
    {
        FindVisibleTargets();
    }

    protected override void ActionViewedObject(Transform target)
    {
        target.GetComponent<EnemyVisibility>().ShowEnemy();
    }
    
}
