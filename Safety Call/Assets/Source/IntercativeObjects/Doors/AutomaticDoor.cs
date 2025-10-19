using System;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour, IHackable
{
    [SerializeField] private Animator _animator;

    [SerializeField] private bool _isActive;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(!_isActive) return;
        
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            _animator.SetBool("isOpened", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(!_isActive) return;
        
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            _animator.SetBool("isOpened", false);
        }
    }

    public void SetIsActive(bool isActive)
    {
        _isActive = isActive;
    }

    public void Hack()
    {
        _isActive = false;
        _animator.SetBool("isOpened", true);
    }
}
