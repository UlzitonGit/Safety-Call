using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameSceneController : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
