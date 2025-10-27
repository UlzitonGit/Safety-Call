using System;
using System.Collections;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    [SerializeField] protected float _prepareBeforeShoot;

    [SerializeField] protected WeaponGeneral _weaponGeneral;
    
    protected bool _startFire;
    
    protected Transform _target;

    protected bool _isShooting;
    
    
    public virtual void StartFire(Transform target, bool prepareMultiply = false)
    {
        _target = target;
         
        StartCoroutine(Preparing(prepareMultiply));
    }
    
    
    public virtual void StopFire()
    {
        StopAllCoroutines();
        
        _startFire = false;
        _isShooting = false;
    }
    protected virtual IEnumerator Preparing(bool prepareMultiply)
    {
        if(prepareMultiply) yield return new WaitForSeconds(_prepareBeforeShoot);
        
        yield return new WaitForSeconds(_prepareBeforeShoot);
        _startFire = true;
        
    }

  
}
