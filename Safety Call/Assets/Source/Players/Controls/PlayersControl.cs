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
    [SerializeField] private CameraTypeSwitcher _cameraSwitcher;
    
    [SerializeField] private PlayerChooser _chooser;
    
    [SerializeField] private Animator _animatorPanelIndividual;
    
    private PlayerMovement _controlingUnit;
    private PlayerData _controlingData;
    
    private bool _isSinglePlayer;

    private InputAction _switchMoveTypeAction;
    
    private PlayerUiDrawer _uiDrawer;

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
        if (_chooser.GetChosenPlayers() == null) 
            return;
        if (!_isSinglePlayer)
        {
            SwitchToSingle(_chooser.GetChosenPlayers()[0]);
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
        _uiDrawer = _playerData._playerHealth.GetComponent<PlayerHealth>().GetPlayerUiDrawer();
        _singlePlayerControl._playerMovement = _controlingUnit;
        _singlePlayerControl.enabled = true;
        //_tacticalControl.enabled = false;
        SwitchPlayerStates(true);
        InputManager.Instance.SwitchActionMapType(ActionMapType.IndividualMove);
        _cameraSwitcher.SwitchCameraToSinglePlayerControl(_playerData._playerMovement.transform);
    }

    public void SwitchToTactic()
    {
        _singlePlayerControl.enabled = false;
        _tacticalControl.enabled = true;
        _isSinglePlayer = false;
        
        SwitchPlayerStates(false);
        InputManager.Instance.SwitchActionMapType(ActionMapType.TacticalMove);
        _cameraSwitcher.SwitchCameraToTacticalControl();
    }

    private void SwitchPlayerStates(bool state)
    {
        _controlingData._PlayerGunfightBehaviour._isControlling = state;
        _uiDrawer.PlayPickAnim(state);
        _controlingUnit._isControlling = state;
        _animatorPanelIndividual.SetBool("Picked", state);
        _controlingData._PlayerWeaponController.SetLocal(state);
        _controlingUnit.StopAgent(state);
        _isSinglePlayer = state;
    }
}
