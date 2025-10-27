using UnityEngine;

public class EnemyWeaponController : WeaponController
{
    private void Update()
    {
            if (_weaponGeneral.IsCanShoot() && _startFire && _target != null)
            {
                _weaponGeneral.Shoot(_target.position);
            }
    }
}
