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
    [SerializeField] private OpenSecondDoor openSecondDoor;
    private InputAction _lookAction;

    private int _curHintId = 0;
    private int _curDialogue = 0;
    private int _curRoom = 1;

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
        /*hintContrller.AfterHintEvent.AddListener(SecondFourthDialogue);
        hintOnTrigger.TriggerEvent.AddListener(SecondThirdHint);*/
    }

    public void SetRoom(int num)
    {
        _curRoom = num;
    }

    private void FirstHint()
    {
        if (_curHintId == 0)
        {
            hintContrller.ShowHint();
            _curHintId++;
        }
    }

    public void SecondDialogue()
    {
        if (_curDialogue == 1)
        {
            dialogueController.StartDialogue(tutorialDialog);
            _curDialogue++;
        }
    }

    public void SecondHint()
    {
        if (_curHintId == 1 && _curRoom == 2)
        {
            hintContrller.ShowHint();
            _curHintId++;
        }
    }

    private void ThirdDialogue(InputAction.CallbackContext ctx)
    {
        if (_curDialogue == 2 && _curRoom == 2)
        {
            dialogueController.StartDialogue(tutorialDialog);
            _curDialogue++;
            _lookAction.performed -= ThirdDialogue;
            openSecondDoor.Open();
        }
    }

    public void ThirdHint()
    {
        if (_curHintId == 2 && _curRoom == 3)
        {
            hintContrller.ShowHint();
            _curHintId++;
        }
    }

    public void FourthDialogue()
    {
        print(_curDialogue);
        print(_curRoom);
        if (_curDialogue == 3 && _curRoom == 3)
        {
            dialogueController.StartDialogue(tutorialDialog);
            _curDialogue++;
        }
    }

}
