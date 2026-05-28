using System.Collections.Generic;
using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask _canInteractLayer = 20;
    [SerializeField] private float _radius = 1;
    private InputAction _interactAction;
    private List<IInteractable> _interactable = new List<IInteractable>();
    private void OnEnable()
    {
        _interactAction = InputManager.Instance.GameInput.Mission.Interact;
        _interactAction.performed += DoInteract;
    }

    private void OnDisable()
    {
        _interactAction.performed -= DoInteract;
    }

    private void DoInteract(InputAction.CallbackContext obj)
    {
        _interactable.Clear();
        Collider2D[] interactions = Physics2D.OverlapCircleAll(transform.position, 1f, _canInteractLayer);
        foreach (Collider2D interactable in interactions)
        {
            if (interactable.TryGetComponent<IInteractable>(out IInteractable i))
            {
                _interactable.Add(i);
            }
        }
        if (_interactable != null)
        {
            foreach (IInteractable interactable in _interactable)
            {
                interactable.DoInteract();
            }
        }
    }
    
}
