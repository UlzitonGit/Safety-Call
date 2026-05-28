using System;
using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using Source.Players.Controls;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
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
        ChoosePause();
    }

    public void ChoosePause()
    {
        if (isPaused)
        {
            Resume();
            isPaused = false;
            pausePanel.SetActive(false);
        }
        else
        {
            Pause();
            isPaused = true;
            pausePanel.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void BackToLoadingScreen()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    private void Pause()
    {
        Time.timeScale = 0;
    }

    private void Resume()
    {
        Time.timeScale = 1;
    }
}
