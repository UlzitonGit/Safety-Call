using Source.Core;
using Source.Players.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilitiesController : MonoBehaviour
{
    [SerializeField] private PlayerChooser _playerChooser;

    private InputAction _useGranadeAction;
    private InputAction _abilityUserAction;
    private InputAction _abilityUserAction2;
    private InputAction _abilityUserAction3;
    private void OnEnable()
    {
        _useGranadeAction = InputManager.Instance.GameInput.Mission.UseGranade;
        _abilityUserAction = InputManager.Instance.GameInput.Mission.UseAbility;
        _abilityUserAction2 = InputManager.Instance.GameInput.Mission.UseAbility1;
        _abilityUserAction3 = InputManager.Instance.GameInput.Mission.UseAbility2;
        
        _useGranadeAction.performed += DoThrow;
        _abilityUserAction.performed += PerformAbilityE;
        _abilityUserAction2.performed += PerformAbilityQ;
        _abilityUserAction3.performed += PerformAbilityD;
        
    }

    private void OnDisable()
    {
        _useGranadeAction.performed -= DoThrow;
        _abilityUserAction.performed -= PerformAbilityE;
        _abilityUserAction2.performed -= PerformAbilityQ;
        _abilityUserAction3.performed -= PerformAbilityD;
    }

    private void DoThrow(InputAction.CallbackContext ctx)
    {
        if (_playerChooser.GetPlayersChosen() == 1 )
        {
            PlayerData _currentPlayerData = _playerChooser.GetChosenPlayers()[0];
            _currentPlayerData._GranadeThrower.Throw(_currentPlayerData._playerMovement.GetClickedCoordinates());
        }
    }

    private void PerformAbilityE(InputAction.CallbackContext ctx)
    {
        if (_playerChooser.GetPlayersChosen() == 1)
        {
            PlayerData _currentPlayerData = _playerChooser.GetChosenPlayers()[0];
            _currentPlayerData._AbilityUser._abilities[0].UseAbility();
        }
    }
    private void PerformAbilityQ(InputAction.CallbackContext ctx)
    {
        if (_playerChooser.GetPlayersChosen() == 1)
        {
            PlayerData _currentPlayerData = _playerChooser.GetChosenPlayers()[0];
            _currentPlayerData._AbilityUser._abilities[1].UseAbility();
        }
    }
    private void PerformAbilityD(InputAction.CallbackContext ctx)
    {
        if (_playerChooser.GetPlayersChosen() == 1)
        {
            PlayerData _currentPlayerData = _playerChooser.GetChosenPlayers()[0];
            _currentPlayerData._AbilityUser._abilities[2].UseAbility();
        }
    }
}
