using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMission : MonoBehaviour
{
    public void OnMissionScene()
    {
        SceneManager.LoadScene(2);
    }
}
