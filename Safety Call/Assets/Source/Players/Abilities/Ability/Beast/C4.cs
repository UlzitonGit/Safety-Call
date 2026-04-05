using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4: MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionSystem;
    
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private GameObject _rocketVisual;
    
    [SerializeField] private float _damage;

    
    [SerializeField] protected LayerMask _targetLayer;
    [SerializeField] protected float _radius;
    
    private bool _isActive = false;
    private bool _canBomb = true;

    private bool _exploded;
    
    private Vector3 _startPosition;
    
    private Rigidbody2D _rigidbody;


    public void Activate()
    {
        Explode(Detonate());
    }
    protected void Explode(List<IDamagable> targets)
    {
        
        if (_canBomb)
        {
            Instantiate(_explosionSystem, transform.position, Quaternion.identity);
            _audioSource.Play();
            _canBomb = false;
            StartCoroutine(Destroy());
            if(targets.Count == 0) return;
            foreach (var target in targets)
            {
                target.GetDamage(_damage, transform.position);
            }
        }
    }
    protected virtual  List<IDamagable> Detonate()
    {
        Collider2D[] hitedObjects = Physics2D.OverlapCircleAll(transform.position, this._radius, _targetLayer);
        List<IDamagable> targets = new List<IDamagable>();
        foreach (Collider2D hitedObject in hitedObjects)
        {
            targets.Add(hitedObject.GetComponent<IDamagable>());
        }
        return targets;
    }

    IEnumerator Destroy()
    {
        _rocketVisual.SetActive(false);
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);
        
    }
}