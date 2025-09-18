using System;
using Source.Creatures.Movement;
using Source.Players.Movement;
using Unity.VisualScripting;
using UnityEngine;

namespace Source.Players.Behaviour
{
    public abstract class GunfightBehaviourManager : MonoBehaviour
    {
        public CreatureStates EnemyTarget{get; private set;}
        
        [SerializeField] protected WeaponGeneral _weapon;
        
        protected CreatureMovement _movement;
        
        protected bool _hasTarget;

        protected virtual void Start()
        {
            _movement = GetComponent<CreatureMovement>();
        }

        protected virtual void Update()
        {
            if (!_hasTarget) return;
            {
                if (!EnemyTarget.IsAlive || !EnemyTarget.IsVisible)
                {
                    EnemyTarget = null;
                    _weapon.StopFire();
                    _hasTarget = false;
                }
            }
        }

        protected virtual bool CheckShootingRelevation()
        {
            return true;
        }
        

        public virtual void AddEnemyTarget(CreatureStates enemy)
        {
            if(EnemyTarget!=null) return;
            EnemyTarget = enemy;
            _hasTarget = true;
            if (CheckShootingRelevation())
            {
                print("TargetAdded");
                _movement.LookAtPosition(enemy.transform.position);
                _weapon.StartFire(EnemyTarget.transform);
            }
        }
    }
}
