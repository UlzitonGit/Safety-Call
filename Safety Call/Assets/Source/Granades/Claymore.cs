using System.Collections;
using System.Collections.Generic;
using Source.Creatures.Health;
using UnityEngine;

public class Claymore : GranadeAbstract
{
    [SerializeField] private ParticleSystem _explosionSystem;
    
    [SerializeField] private AudioSource _audioSource;
    
    [SerializeField] private float _damage;

    private bool _isActive = true;
    
    private bool _exploded;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_exploded && _isActive)
        {
            _explosionSystem.Play();
            _exploded = true;
            _audioSource.Play();
            Throw();
        }
    }
    protected override void ActionTargets(List<CreatureStates> targets)
    {
        foreach (var target in targets)
        {
            target.GetComponent<CreatureHealth>().GetDamage(_damage, transform.position);
        }

        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);
    }

    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }
}
