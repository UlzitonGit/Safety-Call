using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBang : GranadeAbstract
{
    [SerializeField] private float _flashDuration;
    
    [SerializeField] private Animator _animator;
    
    [SerializeField] private AudioSource _audioSource;
    
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private GameObject _sprite;

    protected override void ActionTargets(List<CreatureStates> targets)
    {
        StartCoroutine(FlashTargets(targets));
        _audioSource.PlayOneShot(_audioClip);
        _sprite.SetActive(false);
    }

    IEnumerator FlashTargets(List<CreatureStates> targets)
    {
        foreach (var target in targets)
        {
            target.SetStunned(true);
        }
        _animator.SetTrigger("Flash");
        
        yield return new WaitForSeconds(_flashDuration);
        
        foreach (var target in targets)
        {
            target.SetStunned(false);
        }
        Destroy(gameObject);
    }
}
