using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMission : MonoBehaviour
{
    public void OnMissionScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
