using System;
using Source.Core;
using Source.Players.Controls;
using Source.Players.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersControl : MonoBehaviour
{
    [SerializeField] private PlayerTacticalControlInput _tacticalControl;
    [SerializeField] private PlayerSingleControlInput _singlePlayerControl;
    
    [SerializeField] private PlayerChooser _chooser;
    
    private PlayerMovement _controlingUnit;
    private PlayerData _controlingData;
    
    private bool _isSinglePlayer;

    private InputAction _switchMoveTypeAction;

    private void OnEnable()
    {
        _switchMoveTypeAction = InputManager.Instance.GameInput.Mission.SwitchMoveType;

        _switchMoveTypeAction.performed += DoSwitchMoveType;
    }

    private void OnDisable()
    {
        _switchMoveTypeAction.performed -= DoSwitchMoveType;
    }

    private void DoSwitchMoveType(InputAction.CallbackContext ctx)
    {
        if (_chooser.GetPlayersChoosen() == 1 && !_isSinglePlayer)
        {
            SwitchToSingle(_chooser.GetChosenPlayer()[0]);
        }
        else if (_isSinglePlayer)
        {
            SwitchToTactic();
        }
    }

    public void SwitchToSingle(PlayerData _playerData)
    {
        _controlingUnit = _playerData._playerMovement.GetComponent<PlayerMovement>();
        _controlingData = _playerData;
        _singlePlayerControl._playerMovement = _controlingUnit;
        _singlePlayerControl.enabled = true;
        _tacticalControl.enabled = false;
        SwitchPlayerStates(true);
        InputManager.Instance.SwitchActionMapType(ActionMapType.IndividualMove);
    }

    public void SwitchToTactic()
    {
        _singlePlayerControl.enabled = false;
        _tacticalControl.enabled = true;
        _isSinglePlayer = false;
        SwitchPlayerStates(false);
        InputManager.Instance.SwitchActionMapType(ActionMapType.TacticalMove);
    }

    private void SwitchPlayerStates(bool state)
    {
        _controlingData._PlayerGunfightBehaviour._isControlling = state;
        _controlingData._PlayerWeaponController.SetLocal(state);
        _controlingUnit.StopAgent(state);
        _isSinglePlayer = state;
    }
}
