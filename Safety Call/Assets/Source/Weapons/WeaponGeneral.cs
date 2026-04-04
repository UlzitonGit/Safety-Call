using System;
using System.Collections;
using Source.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class WeaponGeneral : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    
    [SerializeField] protected LayerMask _layersToIgnore;

    [SerializeField] protected WeaponSoundPlayer _weaponSoundPlayer;
    
    [SerializeField] protected ParticleSystem _shootVFX;

    [SerializeField] protected int _maxAmmo;
    
    [SerializeField] protected int _magazineCapacity;
    
    [SerializeField] protected int _currentAmmo;

    [SerializeField] protected float _prepareBeforeShoot;
    
    [SerializeField] protected float _timeBetweenShots;
    [SerializeField] protected float _damage;
    
    [SerializeField] protected float _reloadTime;

    protected float critChance;
    protected Coroutine _shootingCoroutine;
    protected bool _isReloading;

    [SerializeField] private bool _canShoot = true;


    public void SetCritChance(float critChance)
    {
        this.critChance = critChance;
    }

    public virtual void Shoot(Vector3 target)
    {
        if(!_canShoot) return;
        if (_currentAmmo > 0)
        {
            _shootVFX.Play();
            _canShoot = false;
            _weaponSoundPlayer.PlayShootSound();
            _currentAmmo--;
            
            Vector2 direction = (target - transform.position).normalized;
            
            RaycastHit2D hit = Physics2D.Raycast(_shootPoint.position, direction, 100, ~_layersToIgnore);
            Debug.DrawRay(_shootPoint.position, direction * 10f, Color.red, 1);
            
            DealDamage(hit);
            if (critChance >= Random.Range(0f, 100f))
            {
                DealDamage(hit);
            }
            StartCoroutine(DelayBetweenShoots());

        }
        else if(!_isReloading)
        {
            StartCoroutine(Reloading());
        }
    }

    protected virtual void DealDamage(RaycastHit2D hit)
    {
        
    }

    IEnumerator Reloading()
    {
        _isReloading = false;
        _currentAmmo = 0;
        yield return new WaitForSeconds(_reloadTime);
        if (_maxAmmo >= _magazineCapacity)
        {
            _currentAmmo = _magazineCapacity;
            _maxAmmo -= _magazineCapacity;
        }
        _isReloading = true;
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

    public string GetFireRate()
    {
        return (60 / _timeBetweenShots).ToString();
    }

    public float GetDamage()
    {
        return _damage;
    }

    public string GetName()
    {
        return gameObject.name;
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    public int GetMaxAmmo()
    {
        return _maxAmmo;
    }
 
}
