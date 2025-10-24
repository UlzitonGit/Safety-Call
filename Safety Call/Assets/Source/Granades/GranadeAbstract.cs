using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GranadeAbstract : MonoBehaviour, IThrowable
{
    [SerializeField] protected LayerMask _layersToIgnore;
    [SerializeField] protected LayerMask _targetLayer;
    [SerializeField] protected float _radius;
    [SerializeField] protected float _timeToDetonate;
    [SerializeField] protected float _thowPower;
    
    Rigidbody2D _rigidbody;
    
    public void Throw()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(transform.up * _thowPower, ForceMode2D.Impulse);
        StartCoroutine(DetonateCountdown());
    }
    
    protected virtual  List<CreatureStates> Detonate()
    {
        Collider2D[] hitedObjects = Physics2D.OverlapCircleAll(transform.position, this._radius, _targetLayer);
        
        List<CreatureStates> targets = new List<CreatureStates>();
        
        foreach (Collider2D hitedObject in hitedObjects)
        {
            print(hitedObject + "SpotedByFlash");
            Vector2 direction = (hitedObject.transform.position - transform.position).normalized;
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _radius, ~_layersToIgnore);
            Debug.DrawRay(transform.position, direction * 10f, Color.red, 1);
            hit.transform.TryGetComponent<CreatureStates>(out CreatureStates creatureStates);
            if (creatureStates)
            {
                targets.Add(creatureStates);
                print(creatureStates + "FLASHED");
            }
            
        }

        return targets;
    }

    protected IEnumerator DetonateCountdown()
    {
        yield return new WaitForSeconds(_timeToDetonate);
        ActionTargets(Detonate());
    }

    protected virtual void ActionTargets( List<CreatureStates> targets )
    {
        //DoSMTH
    }

  
}
