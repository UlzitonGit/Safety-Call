using System;
using System.Collections;
using Source.Creatures.Movement;
using UnityEngine;

namespace Source.Creatures.Health
{
    public abstract class CreatureHealth : MonoBehaviour
    {
        public float CurrentHealth => _currentHealth;
        [SerializeField] protected GameObject _bloodVfxPrefab;
        
        [SerializeField] protected float _maxHealth;

        [SerializeField] protected float _timeToReaction = 0.4f;
        
        [SerializeField] protected CreaturesData _creaturesData;
        protected float _currentHealth;

        protected CapsuleCollider2D _capsuleCollider2D;
        
        protected bool _isAlive = true;
        
        protected GameplayStagesManager _gameplayStagesManager;
        
       [SerializeField] protected CreatureAnimator _playerAnimator;

        protected virtual void Start()
        {
            _currentHealth = _maxHealth;
            _gameplayStagesManager = FindAnyObjectByType<GameplayStagesManager>();
            _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }

        public virtual void GetDamage(float damage, Vector3 enemyPos)
        {
            _currentHealth -= damage;
            //StartCoroutine(LookAtTarget(enemyPos));
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
            _currentHealth = 0;
            _creaturesData._playerState.SetCanMove(false);
            _creaturesData._playerMovement.StopMovement();
            _capsuleCollider2D.enabled = false;
            _capsuleCollider2D.isTrigger = true;
            _isAlive = false;
        }

        public bool GetIsAlive()
        {
            return _isAlive;
        }
    }
}
