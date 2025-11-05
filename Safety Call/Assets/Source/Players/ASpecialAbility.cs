using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ASpecialAbility : MonoBehaviour
{
    private InputAction _abilityAction;

    private void OnEnable()
    {
        _abilityAction = InputManager.Instance.GameInput.MissionController.UseAbility;

        _abilityAction.canceled += DoAbility;
    }

    private void OnDisable()
    {
        _abilityAction.started -= DoAbility;
    }

    protected abstract void DoAbility(InputAction.CallbackContext ctx);
}
