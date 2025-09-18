using System;
using System.Collections;
using Source.Enemy;
using UnityEngine;

public abstract class WeaponGeneral : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    
    [SerializeField] protected LayerMask _layersToIgnore;
    
    [SerializeField] protected ParticleSystem _shootVfx;
    
    [SerializeField] protected AudioSource _audioSource;
    
    [SerializeField] protected float _timeBetweenShots;
    [SerializeField] protected float _damage;
    
    protected float _currentTimeBetweenShot;
    
    protected bool _startFire;
    
    protected Transform _target;
    private void Start()
    {
        _currentTimeBetweenShot = _timeBetweenShots;
    }

    public virtual void StartFire(Transform target)
    {
         _target = target;
         _startFire = true;
    }
    
    public virtual void StopFire()
    {
        _startFire = false;
    }

    protected virtual void Shoot()
    {
        if (_currentTimeBetweenShot <= 0)
        {
            _shootVfx.Play();
            _audioSource.PlayOneShot(_audioSource.clip);
            print("Shoot");
            Vector2 direction = (_target.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(_shootPoint.position, direction, 100, ~_layersToIgnore);
            Debug.DrawRay(_shootPoint.position, direction * 10f, Color.red, 1);
            DealDamage(hit);
        }
    }

    protected virtual void DealDamage(RaycastHit2D hit)
    {
        
    }

    protected virtual void Update()
    {
        if (_currentTimeBetweenShot > 0 && _startFire)
        {
            _currentTimeBetweenShot -= Time.deltaTime;
            if (_currentTimeBetweenShot <= 0)
            {
                Shoot();
                _currentTimeBetweenShot = _timeBetweenShots;
            }
        }
    }
}
