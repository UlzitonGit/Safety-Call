using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponLoadoutChooser : MonoBehaviour
{
    [SerializeField] private PlayerLoadoutSO _playerLoadout;
    
    [SerializeField] private WeaponGeneral[] _weapons;

    [SerializeField] private Image _weaponIcon;
    
    [SerializeField] private TextMeshProUGUI _fireRateText;
    [SerializeField] private TextMeshProUGUI _ammoText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _nameText;

    private WeaponGeneral _currentWeapon;

    private int _currentWeaponIndex;

    private void Start()
    {
        _currentWeapon = _playerLoadout.Weapon;
        foreach (var weapon in _weapons)
        {
            if (weapon == _playerLoadout.Weapon)
            {
                break;
            }

            _currentWeaponIndex++;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        _weaponIcon.sprite = _currentWeapon.GetComponentInChildren<SpriteRenderer>().sprite;

        _fireRateText.text = "fire rate: " + _currentWeapon.GetFireRate();
        _ammoText.text = "ammo: " + _currentWeapon.GetMaxAmmo();
        _damageText.text = "damage: " + _currentWeapon.GetDamage();
        _nameText.text = "name: " + _currentWeapon.GetName();
    }

    public void NextWeapon()
    {
        _currentWeaponIndex += 1;
        if (_currentWeaponIndex > _weapons.Length - 1)
        {
            _currentWeaponIndex = 0;
        }

        _currentWeapon = _weapons[_currentWeaponIndex];
        _playerLoadout.Weapon = _currentWeapon;
        UpdateUI();
    }
}
