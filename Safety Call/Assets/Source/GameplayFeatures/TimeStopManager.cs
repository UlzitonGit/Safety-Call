using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class TimeStopManager : MonoBehaviour
{
    [SerializeField] private Volume _volume;
    private float _volumeWeight = 0.7f;
    private bool _isStoped;

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
    }

    private void PlayTime()
    {
        _isStoped = false;
        Time.timeScale = 1;
        _volume.weight = 0f;
    }
}
