using System;
using Source.Enemy;
using UnityEngine;

public class PlayerEnemyLooking : MonoBehaviour
{
    [SerializeField] private float _lookingRange;

    [SerializeField] private LayerMask _enemyMask;
    
    private EnemyHealth _nearestEnemy;
    
}
