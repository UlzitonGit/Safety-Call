using System;
using UnityEngine;

public class PlayerWeaponController : WeaponController
{
    [SerializeField] private PlayerSingleControlInput _playerSingleControlInput;
    [SerializeField] private PlayerData _playerData;
    
    private bool _isLocal;
    
    private void Update()
    {
        if (_weaponGeneral.IsCanShoot() && _startFire)
        {
            _weaponGeneral.Shoot(_target.position);
        }

        if (_weaponGeneral.IsCanShoot() && _isLocal && Input.GetMouseButton(0) && _playerData._playerState.IsAlive)
        {
            _weaponGeneral.Shoot(_playerSingleControlInput.GetClickCoordinates());
        }
    }

    public void SetLocal(bool isLocal)
    {
        this._isLocal = isLocal;
    }
}
