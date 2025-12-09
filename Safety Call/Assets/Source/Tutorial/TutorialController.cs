using Source.Core;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private HintContrller hintContrller;
    [SerializeField] private DialoguesDataSO tutorialDialog;
    [SerializeField] private HintOnTrigger hintOnTrigger;
    private InputAction _lookAction;

    private int _curHintId = 0;
    private int _curDialogue = 0;

    private void OnEnable()
    {
        _lookAction = InputManager.Instance.GameInput.TacticalMove.Turn;
        _lookAction.performed += ThirdDialogue;
    }

    private void OnDisable()
    {
        _lookAction.performed -= ThirdDialogue;
    }

    void Start()
    {
        dialogueController.StartDialogue(tutorialDialog);
        _curDialogue++;
        dialogueController.DialogueEndEvent.AddListener(FirstHint);
        hintContrller.AfterHintEvent.AddListener(SecondDialogue);
        hintOnTrigger.TriggerEvent.AddListener(SecondHint);
        hintOnTrigger.TriggerEvent.AddListener(ThirdHint);
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
        if (_curDialogue == 1)
        {
            dialogueController.StartDialogue(tutorialDialog);
            _curDialogue++;
        }
    }

    private void SecondHint()
    {
        if (_curHintId == 1)
        {
            hintContrller.ShowHint();
            _curHintId++;
        }
    }

    private void ThirdDialogue(InputAction.CallbackContext ctx)
    {
        if (_curDialogue == 2)
        {
            dialogueController.StartDialogue(tutorialDialog);
            _curDialogue++;
            _lookAction.performed -= ThirdDialogue;
        }
    }

    private void ThirdHint()
    {
        if (_curHintId == 2)
        {
            hintContrller.ShowHint();
            _curHintId++;
        }
    }
}
