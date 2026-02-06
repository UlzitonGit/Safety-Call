using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class Medkit : MonoBehaviour
{
    [SerializeField] private int healPoints;
    [SerializeField] private GameObject hint;
    [SerializeField] private bool isStation;
    private bool _canInteract = false;
    private bool _isUsed = false;
    private PlayerHealth _curPlayerHealth;

    private InputAction _interactAction;

    private void OnEnable()
    {
        _interactAction = InputManager.Instance.GameInput.Mission.Interact;
        _interactAction.performed += DoInteract;
    }

    private void OnDisable()
    {
        _interactAction.performed -= DoInteract;
    }

    private void DoInteract(InputAction.CallbackContext ctx)
    {
        if (_canInteract)
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isUsed)
        {
            if (collision.tag == "Player")
            {
                _curPlayerHealth = collision.GetComponent<PlayerHealth>();
                hint.SetActive(true);
                _canInteract = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _curPlayerHealth = null;
            hint.SetActive(false);
            _canInteract = false;
        }
    }
}
