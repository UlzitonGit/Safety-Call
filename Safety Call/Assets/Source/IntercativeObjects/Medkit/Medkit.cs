using System;
using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class Medkit : MonoBehaviour, IInteractable
{
    [SerializeField] private int healPoints;
    [SerializeField] private GameObject hint;
    [SerializeField] private bool isStation;
    private bool _canInteract = false;
    private bool _isUsed = false;
    private PlayerHealth _curPlayerHealth;

    private InputAction _interactAction;
    

    public void DoInteract()
    {
            if (!_isUsed)
            {
                if (_curPlayerHealth != null)
                {
                    if (_curPlayerHealth.TryGetComponent<FerretPassive>(out var ferretPassive))
                    {
                        _curPlayerHealth.AddHealth(100);
                        ferretPassive.AddHealingPistolAmmo(healPoints / 10);
                    }
                    _curPlayerHealth.AddHealth(healPoints);
                    if (!isStation)
                    {
                        _isUsed = true;
                        Destroy(gameObject);
                    }
                    
                }
            }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hint.SetActive(true);
            collision.GetComponent<PlayerInteraction>().SetInteractable(this);
            _curPlayerHealth = collision.GetComponent<PlayerHealth>();
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            hint.SetActive(false);
            collision.GetComponent<PlayerInteraction>().SetInteractable(null);
        }
    }

}
