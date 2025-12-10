using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameSceneController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    private bool _isPaused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("paused");
            if (_isPaused) Resume();
            else Pause();
        }
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
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
