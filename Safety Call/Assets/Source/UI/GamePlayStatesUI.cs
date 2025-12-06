using UnityEngine;

public class GamePlayStatesUI : MonoBehaviour
{
    [SerializeField] private GameObject[] tasksPanel;

    public void CloseTask(int taskID)
    {
        tasksPanel[taskID].SetActive(false);
    }
}
