using UnityEngine;
using UnityEngine.InputSystem;

public class BeastBalisticShield : ASpecialAbility
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private ItemsSwitcher _switcher;
    [SerializeField] private GameObject _shield;
    
    private bool _shieldActive;

    protected override void DoAbility(InputAction.CallbackContext ctx)
    {
        if (_playerData._PlayerGunfightBehaviour._isControlling && !_shieldActive)
        {
            _switcher.SwitchToTargetedObject(_shield);
            _shieldActive = true;
        }
        else if (_playerData._PlayerGunfightBehaviour._isControlling && _shieldActive)
        {
            _switcher.SwitchToIndexObject(0);
            print("SwitchToIndexObject");
            _shieldActive = false;
        }
    }
}
