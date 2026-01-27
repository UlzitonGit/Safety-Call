using System;
using System.Collections;
using System.Collections.Generic;
using Source.Creatures.Health;
using UnityEngine;

public class RPGRocket: MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionSystem;
    
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private GameObject _rocketVisual;
    
    [SerializeField] private float _damage;

    [SerializeField] private float _speed;
    
    [SerializeField] protected LayerMask _layersToIgnore;
    [SerializeField] protected LayerMask _targetLayer;
    [SerializeField] protected float _radius;
    [SerializeField] protected float _timeToDetonate;
    [SerializeField] protected float _thowPower;
    
    private bool _isActive = false;
    private bool _canBomb = true;

    private bool _exploded;
    
    private Vector3 _startPosition;
    
    private Rigidbody2D _rigidbody;
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(transform.up * _thowPower, ForceMode2D.Impulse);
        _startPosition = transform.position;
    }

    private void Update()
    { 
        if(_isActive) return;
        _isActive = Vector3.Distance(transform.position, _startPosition) > 1.4f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_exploded && _isActive)
        {
            _exploded = true;
            Explode(Detonate());
        }
    }
    protected void Explode(List<IDamagable> targets)
    {
        if (_canBomb)
        {
            Instantiate(_explosionSystem, transform.position, Quaternion.identity);
            _audioSource.Play();
            foreach (var target in targets)
            {
                target.GetDamage(_damage, transform.position);
            }
            _canBomb = false;
            StartCoroutine(Destroy());
        }
    }
    protected virtual  List<IDamagable> Detonate()
    {
        Collider2D[] hitedObjects = Physics2D.OverlapCircleAll(transform.position, this._radius, _targetLayer);
        
        List<IDamagable> targets = new List<IDamagable>();
        
        foreach (Collider2D hitedObject in hitedObjects)
        {
            Vector2 direction = (hitedObject.transform.position - transform.position).normalized;
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _radius, ~_layersToIgnore);
            Debug.DrawRay(transform.position, direction * 10f, Color.red, 1);
            hit.transform.TryGetComponent(out IDamagable creatureStates);
            if (creatureStates != null)
            {
                targets.Add(creatureStates);
                print(creatureStates);
            }
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