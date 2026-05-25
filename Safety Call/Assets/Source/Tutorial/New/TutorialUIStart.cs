using UnityEngine;

public class TutorialUIStart : MonoBehaviour, IStartable
{
    [SerializeField] private GameObject dialogPanel;
   

    public void StartAction()
    {
        dialogPanel.SetActive(true);
    }
}
