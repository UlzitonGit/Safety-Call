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
        
        protected CreatureMovement _movement;
        
        protected bool _isAlive = true;
        
        protected GameplayStagesManager _gameplayStagesManager;

        protected virtual void Start()
        {
            _currentHealth = _maxHealth;
            _movement = GetComponent<CreatureMovement>();
            _gameplayStagesManager = FindAnyObjectByType<GameplayStagesManager>();
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
            _isAlive = false;
        }
    }
}
