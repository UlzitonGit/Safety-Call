using UnityEngine;

public class MoveTutorial : MonoBehaviour
{
    [SerializeField] private TutorialController _tutorialController;
    [SerializeField] private GameObject uiHint;
    [SerializeField] private string name;
    private bool isUsed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == name && !isUsed)
        {
            isUsed = true;
            print("Next Stage");
            gameObject.SetActive(false);
            uiHint.SetActive(false);
            _tutorialController.NextStage();
        }
    }
}
