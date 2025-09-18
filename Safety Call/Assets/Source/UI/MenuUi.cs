using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUi : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
