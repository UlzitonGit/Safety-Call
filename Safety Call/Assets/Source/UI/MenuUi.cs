using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUi : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    public void StartGame()
    {
        loadingScreen.gameObject.SetActive(true);
        StartCoroutine(LoadAsync());
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene(5);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame(int index)
    {
        SceneManager.LoadScene(index);
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            if (async.progress >= 0.9f && !async.allowSceneActivation)
            {
                yield return new WaitForSeconds(2f);
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
