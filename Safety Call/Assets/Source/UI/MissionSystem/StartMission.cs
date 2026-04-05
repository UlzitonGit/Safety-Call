using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMission : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    public void OnMissionScene(int index)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(index));
    }
    IEnumerator LoadAsync(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            if (async.progress >= 0.9f && !async.allowSceneActivation)
            {
                yield return new WaitForSeconds(5);
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
