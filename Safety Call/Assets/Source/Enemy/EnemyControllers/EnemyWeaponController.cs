using System;
using UnityEngine;

public class EnemyWeaponController : WeaponController
{
    private void Start()
    {
        _weaponGeneral = GetComponentInChildren<WeaponGeneral>();
    }

    private void Update()
    {
            if (_weaponGeneral.IsCanShoot() && _startFire && _target != null)
            {
                _weaponGeneral.Shoot(_target.position);
            }
    }
}
