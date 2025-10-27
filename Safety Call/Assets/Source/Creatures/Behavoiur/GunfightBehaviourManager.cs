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
        
        [SerializeField] protected WeaponController _weapon;
        
       [SerializeField] protected CreaturesData _creaturesData;
        
        protected bool _hasTarget;

        protected bool _canShoot = true;

        protected bool _isShooting = false;

      

        protected virtual void Update()
        {
            if (!_hasTarget) return;
            
            if (_creaturesData._playerState.IsStunned && _isShooting)
            {
                _weapon.StopFire();
                _isShooting = false;
            }
            
            {
                if (!EnemyTarget.IsAlive || !EnemyTarget.IsVisible)
                {
                    EnemyTarget = null;
                    _weapon.StopFire();
                    _isShooting = false;
                    _hasTarget = false;
                }
            }
        }

        public bool IsHasTarget()
        {
            return _hasTarget;
        }

        public virtual void AddEnemyTarget(CreatureStates enemy)
        {
            if(EnemyTarget !=null || _hasTarget || !_canShoot || !enemy.IsAlive) return;
            EnemyTarget = enemy;
            _hasTarget = true;
            if (CheckShootingRelevation())
            {
                print("TargetAdded " + _hasTarget);
                _creaturesData._playerMovement.LookAtTarget(enemy.transform.position);
                _weapon.StartFire(EnemyTarget.transform);
                _isShooting = true;
            }
        }

      

        public void SetIsAbleToShoot(bool isAbleToShoot)
        {
            _canShoot = isAbleToShoot;
            if (!_canShoot)
            {
                _weapon.StopFire();
            }
        }
        
        protected virtual bool CheckShootingRelevation()
        {
            return true;
        }
        
    }
}
