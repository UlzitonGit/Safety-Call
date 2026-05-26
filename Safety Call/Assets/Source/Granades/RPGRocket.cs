using System.Collections;
using System.Collections.Generic;
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
        if (!_exploded && _isActive && !other.CompareTag("Player"))
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