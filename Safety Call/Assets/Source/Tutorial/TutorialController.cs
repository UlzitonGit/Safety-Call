using UnityEditor.Build;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private HintContrller hintContrller;
    [SerializeField] private DialoguesDataSO tutorialDialog;

    private int _curHintId = 0;

    
    void Start()
    {
        dialogueController.StartDialogue(tutorialDialog);
        dialogueController.DialogueEndEvent.AddListener(FirstHint);
        hintContrller.SecondHintEvent.AddListener(SecondDialogue);
    }

    private void FirstHint()
    {
        if (_curHintId == 0)
        {
            hintContrller.ShowHint();
            _curHintId++;
        }
    }

    private void SecondDialogue()
    {
        if (_curHintId == 1)
        {
            dialogueController.StartDialogue(tutorialDialog);
        }
    }
}
