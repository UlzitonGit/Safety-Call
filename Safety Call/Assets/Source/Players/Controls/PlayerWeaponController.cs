using System;
using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponController : WeaponController
{
    [SerializeField] private PlayerSingleControlInput _playerSingleControlInput;
    [SerializeField] private PlayerData _playerData;

     private InputAction _shootAction;

    private bool _startLocalShoot = false;
    private bool _isLocal;
    private AudioFightMixer _audioFightMixer;

    private void Start()
    {
        _audioFightMixer = FindAnyObjectByType<AudioFightMixer>();
    }

    private void OnEnable()
    {
        _shootAction = InputManager.Instance.GameInput.IndividualMove.Shoot;

        _shootAction.started += StartShoot;
        _shootAction.canceled += StopShoot;
    }

    private void Update()
    {
        if (_weaponGeneral.IsCanShoot() && _startFire)
        {
            _weaponGeneral.Shoot(_target.position);
            _audioFightMixer.StartFightSong();
        }

        if (_weaponGeneral.IsCanShoot() && _isLocal && _startLocalShoot && _playerData._playerState.IsAlive)
        {
            _weaponGeneral.Shoot(_playerSingleControlInput.GetClickCoordinates());
        }
    }

    private void OnDisable()
    {
        _shootAction.started -= StartShoot;
        _shootAction.canceled -= StopShoot;
    }

    private void StartShoot(InputAction.CallbackContext ctx)
    {
        _startLocalShoot = true;
        
    }

    private void StopShoot(InputAction.CallbackContext ctx)
    {
        _startLocalShoot = false;
    }

    public void SetLocal(bool isLocal)
    {
        this._isLocal = isLocal;
    }
}
