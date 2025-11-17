using Source.Core;
using Source.Players.Controls;
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
        InputManager.Instance.SwitchActionMapType(ActionMapType.TacticalMove);
    }

    private void PlayTime()
    {
        _isStoped = false;
        Time.timeScale = 1;
        InputManager.Instance.SwitchActionMapType(_mapType);
        _volume.weight = 0f;
    }
}
