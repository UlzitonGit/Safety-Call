using System;
using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponController : WeaponController
{
    [SerializeField] private PlayerData _playerData;
     private InputAction _shootAction;

    private bool _startLocalShoot = false;
    private bool _isLocal;
    private AudioFightMixer _audioFightMixer;

    private void Start()
    {
        _audioFightMixer = FindAnyObjectByType<AudioFightMixer>();
    }
    
    private void Update()
    {
        if (_weaponGeneral.IsCanShoot() && _startFire)
        {
            _weaponGeneral.Shoot(_target.position);
            _audioFightMixer.StartFightSong();
        }
        
    }
    
}
