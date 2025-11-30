using Source.Core;
using Source.Players.Controls;
using Source.Players.Movement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class TimeStopManager : MonoBehaviour
{
    [SerializeField] private Volume _volume;
    [SerializeField] private PlayerChooser _playerChooser;
    
    private float _volumeWeight = 0.7f;
    private bool _isStoped;
    
    private ActionMapType _mapType;

    private InputAction _timeDilationAction;

    private PlayerData _playerPicked;
    private void OnEnable()
    {
        _timeDilationAction = InputManager.Instance.GameInput.Mission.TimeDilation;

        _timeDilationAction.performed += DoTimeDilation;
    }

    private void OnDisable()
    {
        _timeDilationAction.performed -= DoTimeDilation;
    }

    private void DoTimeDilation(InputAction.CallbackContext ctx)
    {
        if (!_isStoped && Input.GetKeyDown(KeyCode.Space))
        {
            StopTime();
        }
        else if (_isStoped && Input.GetKeyDown(KeyCode.Space))
        {
            PlayTime();
        }
    }

    private void StopTime()
    {
        _isStoped = true;
        Time.timeScale = 0.02f;
        _volume.weight = _volumeWeight;
        _mapType = InputManager.Instance.CurentActionMapType;
        if (_mapType == ActionMapType.IndividualMove)
        {
            _playerPicked = _playerChooser.GetChosenPlayers()[0];
        }
        InputManager.Instance.SwitchActionMapType(ActionMapType.TacticalMove);
    }

    private void PlayTime()
    {
        _isStoped = false;
        Time.timeScale = 1;
        if (_mapType == ActionMapType.IndividualMove)
        {
            _playerChooser.SetPlayerByData(_playerPicked.GetComponent<PlayerMovement>());
        }
        InputManager.Instance.SwitchActionMapType(_mapType);
        _volume.weight = 0f;
    }
}
