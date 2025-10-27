using System;
using Source.Players.Controls;
using Source.Players.Movement;
using UnityEngine;

public class PlayersControl : MonoBehaviour
{
    [SerializeField] private PlayerTacticalControlInput _tacticalControl;
    [SerializeField] private PlayerSingleControlInput _singlePlayerControl;
    
    [SerializeField] private PlayerChooser _chooser;
    
    private PlayerMovement _controlingUnit;
    private PlayerData _controlingData;
    
    private bool _isSinglePlayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _chooser.GetPlayersChoosen() == 1 && !_isSinglePlayer)
        {
            SwitchToSingle(_chooser.GetChosenPlayer()[0]);
        }
        else if (Input.GetKeyDown(KeyCode.F) && _isSinglePlayer)
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
    }

    public void SwitchToTactic()
    {
        _singlePlayerControl.enabled = false;
        _tacticalControl.enabled = true;
        _isSinglePlayer = false;
        SwitchPlayerStates(false);
    }

    private void SwitchPlayerStates(bool state)
    {
        _controlingData._PlayerGunfightBehaviour._isControlling = state;
        _controlingData._PlayerWeaponController.SetLocal(state);
        _controlingUnit.StopAgent(state);
        _isSinglePlayer = state;
    }
}
