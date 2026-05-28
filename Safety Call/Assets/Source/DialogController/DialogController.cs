using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour, IStartable
{
    [SerializeField] private DialogSO[] dialog;
    [SerializeField ] private TextMeshProUGUI textMeshPro;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private Image speakerIcon;
    [SerializeField] private bool isTutorial;
    [SerializeField] private Button nextButton;
    private int replicaIndex = 0;
    private int dialogIndex = 0;
    
    public void StartDialog(int _dialogIndex)
    {
        dialogIndex = _dialogIndex;
        dialogPanel.SetActive(true);
        nextButton.onClick.AddListener(() => NextReplica());
        replicaIndex = 0;
        textMeshPro.text = dialog[dialogIndex].replics[replicaIndex];
        speakerIcon.sprite = dialog[dialogIndex].images[replicaIndex];
        Time.timeScale = 0f;
    }
    
    public void NextReplica()
    {
        replicaIndex++;
        if (replicaIndex >= dialog[dialogIndex].replics.Length)
        {
            EndDialog();
            return;
        }
        textMeshPro.text = dialog[dialogIndex].replics[replicaIndex];
        speakerIcon.sprite = dialog[dialogIndex].images[replicaIndex];
    }

    public void EndDialog()
    {
        dialogPanel.SetActive(false);
        if (isTutorial)
        {
            FindAnyObjectByType<TutorialController>().NextStage();
        }
        nextButton.onClick.RemoveAllListeners();
        Time.timeScale = 1f;
    }

    public void StartAction()
    {
        StartDialog(dialogIndex);
    }
}
