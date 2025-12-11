using Source.Core;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InGameSceneController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    private bool _isPaused = false;

    private InputAction _toMenuAction;

    private void OnEnable()
    {
        _toMenuAction = InputManager.Instance.GameInput.Base.Menu;
        _toMenuAction.performed += DoOpenMenu;
    }

    private void OnDisable()
    {
        _toMenuAction.performed -= DoOpenMenu;
    }

    private void DoOpenMenu(InputAction.CallbackContext ctx)
    {
        if (_isPaused) 
            Resume();
        else Pause();
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void BackToHub()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    private void Pause()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
        _isPaused = true;
    }

    private void Resume()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
        _isPaused = false;
    }
}
