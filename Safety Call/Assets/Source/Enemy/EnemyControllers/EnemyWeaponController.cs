using System;
using UnityEngine;

public class EnemyWeaponController : WeaponController
{
    private AudioFightMixer _audioFightMixer;
    private void Start()
    {
        _weaponGeneral = GetComponentInChildren<WeaponGeneral>();
        _audioFightMixer = FindAnyObjectByType<AudioFightMixer>();
    }

    private void Update()
    {
            if (_weaponGeneral.IsCanShoot() && _startFire && _target != null)
            {
                _weaponGeneral.Shoot(_target.position);
                _audioFightMixer.StartFightSong();
            }
    }
}
