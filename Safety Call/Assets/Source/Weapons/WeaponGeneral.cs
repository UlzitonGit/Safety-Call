using System;
using System.Collections;
using Source.Enemy;
using UnityEngine;

public abstract class WeaponGeneral : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    
    [SerializeField] protected LayerMask _layersToIgnore;

    [SerializeField] protected WeaponSoundPlayer _weaponSoundPlayer;
    
    [SerializeField] protected ParticleSystem _shootVFX;
    
    [SerializeField] protected float _timeBetweenShots;
    [SerializeField] protected float _damage;
    
    protected Coroutine _shootingCoroutine;
    
    protected bool _startFire;
    
    protected Transform _target;

    protected bool _isShooting;

    public virtual void StartFire(Transform target)
    {
         _target = target;
         _startFire = true;
         
         StartCoroutine(Shooting());
    }
    
    public virtual void StopFire()
    {
        StopAllCoroutines();
        
        _startFire = false;
        _isShooting = false;
    }

    protected virtual void Shoot()
    {
            _shootVFX.Play();
            _weaponSoundPlayer.PlayShootSound();
            
            Vector2 direction = (_target.position - transform.position).normalized;
            
            RaycastHit2D hit = Physics2D.Raycast(_shootPoint.position, direction, 100, ~_layersToIgnore);
            Debug.DrawRay(_shootPoint.position, direction * 10f, Color.red, 1);
            
            DealDamage(hit);
        
    }

    protected virtual void DealDamage(RaycastHit2D hit)
    {
        
    }

    protected IEnumerator Shooting()
    {
        yield return new WaitForSeconds(_timeBetweenShots);
        if (_startFire)
        {
            Shoot();
            _shootingCoroutine = StartCoroutine(Shooting());
        }
    }
}
