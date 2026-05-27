using System;
using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using Source.Players.Controls;


public class PauseManager : MonoBehaviour
{
    private InputAction _pause;
    private bool isPaused = false;

    private void OnEnable()
    {
        _pause = InputManager.Instance.GameInput.UI.Exit;
        _pause.performed += UsePause;
    }

    private void OnDisable()
    {
        _pause.performed -= UsePause;
    }

    private void UsePause(InputAction.CallbackContext ctx)
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
