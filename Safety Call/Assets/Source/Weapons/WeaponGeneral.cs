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

    [SerializeField] protected float _prepareBeforeShoot;
    
    [SerializeField] protected float _timeBetweenShots;
    [SerializeField] protected float _damage;
    
    protected Coroutine _shootingCoroutine;

    [SerializeField] private bool _canShoot = true;
    
    
    

    public virtual void Shoot(Vector3 target)
    {
        if(!_canShoot) return;
            _shootVFX.Play();
             _canShoot = false;
            _weaponSoundPlayer.PlayShootSound();
            
           Vector2 direction = (target - transform.position).normalized;
            
            RaycastHit2D hit = Physics2D.Raycast(_shootPoint.position, direction, 100, ~_layersToIgnore);
            Debug.DrawRay(_shootPoint.position, direction * 10f, Color.red, 1);
            
            DealDamage(hit);
            StartCoroutine(DelayBetweenShoots());

    }

    protected virtual void DealDamage(RaycastHit2D hit)
    {
        
    }

    IEnumerator DelayBetweenShoots()
    {
        yield return new WaitForSeconds(_timeBetweenShots);
        _canShoot = true;
    }

    public bool IsCanShoot()
    {
        return _canShoot;
    }

 
}
