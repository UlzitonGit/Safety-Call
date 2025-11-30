using Source.Core;
using Source.Players.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilitiesController : MonoBehaviour
{
    [SerializeField] private PlayerChooser _playerChooser;

    private InputAction _useGranadeAction;

    private void OnEnable()
    {
        _useGranadeAction = InputManager.Instance.GameInput.Mission.UseGranade;

        _useGranadeAction.performed += DoThrow;
    }

    private void OnDisable()
    {
        _useGranadeAction.performed -= DoThrow;
    }

    private void DoThrow(InputAction.CallbackContext ctx)
    {
        if (_playerChooser.GetPlayersChosen() == 1 )
        {
            PlayerData _currentPlayerData = _playerChooser.GetChosenPlayers()[0];
            _currentPlayerData._GranadeThrower.Throw(_currentPlayerData._playerMovement.GetClickedCoordinates());
        }
    }
}
