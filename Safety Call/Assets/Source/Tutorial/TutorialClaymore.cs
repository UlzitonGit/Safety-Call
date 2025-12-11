using System.Collections;
using System.Collections.Generic;
using Source.Creatures.Health;
using UnityEngine;

public class TutorialClaymore : GranadeAbstract
{
    [SerializeField] private ParticleSystem _explosionSystem;

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private GameObject _parent;

    [SerializeField] private float _damage;
    [SerializeField] private bool isTutorial;

    private bool _isActive = true;
    private bool _canBomb = true;

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
        if (_canBomb)
        {
            foreach (var target in targets)
            {
                target.GetComponent<CreatureHealth>().GetDamage(_damage, transform.position);
            }
            _canBomb=false;
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(4f);
      
        if (!isTutorial)
        {
            print("bomb is die");
            Destroy(_parent);
            gameObject.SetActive(false);
        }
        _canBomb = true;
    }

    public void Deactivate()
    {
        _isActive = false;
        Destroy(_parent);
        gameObject.SetActive(false);

    }

    public bool IsActive()
    {
        return _isActive;
    }
}
