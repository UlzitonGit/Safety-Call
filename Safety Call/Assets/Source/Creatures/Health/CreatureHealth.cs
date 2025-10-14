using System;
using Source.Creatures.Movement;
using UnityEngine;

namespace Source.Creatures.Health
{
    public abstract class CreatureHealth : MonoBehaviour
    {
        public float CurrentHealth => _currentHealth;
        [SerializeField] protected GameObject _bloodVfxPrefab;
        
        [SerializeField] protected float _maxHealth;
        protected float _currentHealth;

        protected CapsuleCollider2D _capsuleCollider2D;
        
        protected CreatureMovement _movement;
        
        protected bool _isAlive = true;
        
        protected GameplayStagesManager _gameplayStagesManager;
        
        protected PlayerAnimator _playerAnimator;

        protected virtual void Start()
        {
            _currentHealth = _maxHealth;
            _movement = GetComponent<CreatureMovement>();
            _gameplayStagesManager = FindAnyObjectByType<GameplayStagesManager>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }

        public virtual void GetDamage(float damage, Vector3 enemyPos)
        {
            _currentHealth -= damage;
            _movement.LookAtTarget(enemyPos);
            Instantiate(_bloodVfxPrefab, transform.position, Quaternion.identity);
            print(_currentHealth);
            CheckHealth();
        }

        protected virtual void CheckHealth()
        {
            if (_currentHealth <= 0 && _isAlive)
            {
                Death();
            }
        }

        protected virtual void Death()
        {
            if(!_isAlive) return;
            _playerAnimator.Death();
            _capsuleCollider2D.enabled = false;
            _movement.SetCanMove(false);
            _isAlive = false;
        }
    }
}
