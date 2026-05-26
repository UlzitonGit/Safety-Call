using UnityEngine;

public class BeastShieldAbilitie : AbilityBase
{
    [SerializeField] private WeaponController _weaponController;
    [SerializeField] private GameObject _shieldPrefab;
    private bool _shieldActive;
    public override void UseAbility()
    {
        if (!_shieldActive)
        {
            _weaponController.enabled = false;
            _shieldPrefab.SetActive(true);
        }
        else
        {
            _weaponController.enabled = true;
            _shieldPrefab.SetActive(false);
        }
        _shieldActive = !_shieldActive;
    }
    public override void ShowHint()
    {
        _hint.SetActive(true);
    }

    public override void Cancel()
    {
        _hint.SetActive(false);
    }
}
