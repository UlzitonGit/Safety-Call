using System;
using UnityEngine;

namespace Source.Creatures.Health
{
    public abstract class CreatureHealth : MonoBehaviour
    {
        [SerializeField] protected float _maxHealth;
        protected float _currentHealth;

        protected bool _isAlive;

        protected virtual void Start()
        {
            _currentHealth = _maxHealth;
        }

        public virtual void GetDamage(float damage)
        {
            _currentHealth -= damage;
            print(_currentHealth);
            CheckHealth();
        }

        protected virtual void CheckHealth()
        {
            if (_currentHealth <= 0)
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
