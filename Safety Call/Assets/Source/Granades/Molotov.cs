using System.Collections;
using System.Collections.Generic;
using Source.Creatures.Health;
using UnityEngine;

public class Molotov : GranadeAbstract
{
    [SerializeField] private ParticleSystem _fireParticles;
    [SerializeField] private float _damage;
    [SerializeField] private GameObject _light;
    private bool isFired = false;

    protected void ActionTargets(List<IDamagable> targets)
    {
        if (!isFired)
        {
            StartCoroutine(DestroyGranade());
            isFired = true;
        }
        foreach (IDamagable target in targets)
        {
            target.GetDamage(_damage, transform.position);
        }
        
    }

    protected  List<IDamagable> Detonate()
    {
        Collider2D[] hitedObjects = Physics2D.OverlapCircleAll(transform.position, this._radius, _targetLayer);
        List<IDamagable> targets = new List<IDamagable>();
        foreach (Collider2D hitedObject in hitedObjects)
        {
            targets.Add(hitedObject.GetComponent<IDamagable>());
        }
        return targets;
    }

    IEnumerator DestroyGranade()
    {
        _fireParticles.Play();
        _light.SetActive(true);
        _rigidbody.linearVelocity = new Vector2(0, 0);
        _rigidbody.isKinematic = true;
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(1);
            ActionTargets(Detonate());
        }
        
        Destroy(gameObject);
    }

    protected override IEnumerator DetonateCountdown()
    {
        yield return new WaitForSeconds(_timeToDetonate);
        ActionTargets(Detonate());
    }
}
