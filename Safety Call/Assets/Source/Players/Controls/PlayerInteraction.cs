using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{

    private InputAction _interactAction;
    private IInteractable _interactable;
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
        if (_interactable != null)
        {
            _interactable.DoInteract();
        }
    }

    public void SetInteractable(IInteractable interactable)
    {
        _interactable = interactable;
    }
}
