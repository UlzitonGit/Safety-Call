using Source.Core;
using Source.Players.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private PlayerChooser playerChooser;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private HintContrller hintContrller;
    [SerializeField] private DialoguesDataSO tutorialDialog;
    [SerializeField] private HintOnTrigger hintOnTrigger;
    [SerializeField] private OpenSecondDoor openSecondDoor;
    [SerializeField] private PlayerHealth cuberHealth;

    [Header("-----------")]
    [SerializeField] private GameObject card1;
    [SerializeField] private GameObject card2;
    private InputAction _lookAction;

    private int _curHintId = 0;
    private int _curDialogue = 0;
    private int _curRoom = 1;
    private int _curPlayerPrefs;

    private void OnEnable()
    {
        _curPlayerPrefs = PlayerPrefs.GetInt("PlayerPrefs");
        PlayerPrefs.SetInt("CurLevel", 10);
        _lookAction = InputManager.Instance.GameInput.TacticalMove.Turn;
        _lookAction.performed += ThirdDialogue;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("CurLevel", _curPlayerPrefs);
        _lookAction.performed -= ThirdDialogue;
    }

    void Start()
    {
        foreach(DialogueData dialogue in tutorialDialog.DialogueData)
        {
            dialogue.AlreadyBeen = false;
        }
        dialogueController.StartDialogue(tutorialDialog);
        _curDialogue++;
        cuberHealth.TutorialDeath();
    }

    public void SetRoom(int num)
    {
        _curRoom = num;
    }

    public void FirstHint()
    {
        if (_curHintId == 0)
        {
            hintContrller.StartHint();
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
            hintContrller.StartHint();
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
            hintContrller.StartHint();
            _curHintId++;
        }
    }

    public void FourthDialogue()
    {
        if (_curDialogue == 3 && _curRoom == 3)
        {
            dialogueController.StartDialogue(tutorialDialog);
            _curDialogue++;
        }
    }

    public void FifthDialogue()
    {
        if (_curDialogue == 4 && _curRoom == 5)
        {
            dialogueController.StartDialogue(tutorialDialog);
            _curDialogue++;
        }
    }

    public void FourthHint()
    {
        if (_curHintId == 3 && _curRoom == 5)
        {
            hintContrller.StartHint();
            _curHintId++;
        }
    }

    public void SixthDialogue()
    {
        if (_curDialogue == 5 && _curRoom == 5)
        {
            dialogueController.StartDialogue(tutorialDialog);
            _curDialogue++;
        }
    }

    public void FifthHint()
    {
        if (_curHintId == 4 && _curRoom == 5)
        {
            hintContrller.StartHint();
            _curHintId++;
        }
    }

    public void SeventhDialogue()
    {
        if (_curDialogue == 6 && _curRoom == 6)
        {
            dialogueController.StartDialogue(tutorialDialog);
            _curDialogue++;
        }
    }

    public void SixthHint()
    {
        if (_curHintId == 5 && _curRoom == 6)
        {
            hintContrller.StartHint();
            _curHintId++;
        }
    }

    public void EighthDialogue()
    {
        if (_curDialogue == 7 && _curRoom == 7)
        {
            print("8 dialogue start");
            dialogueController.StartDialogue(tutorialDialog);
            card1.SetActive(true);
            card2.SetActive(true);
            playerChooser.AbilitySelectAll();
            _curDialogue++;
        }
    }

    public void SeventhHint()
    {
        if (_curHintId == 6 && _curRoom == 7)
        {
            print("7 hint");
            hintContrller.StartHint();
            _curHintId++;
        }
    }

    public void NinthDialogue()
    {
        if (_curDialogue == 8 && _curRoom == 7)
        {
            print("10 dialogue");
            dialogueController.StartDialogue(tutorialDialog);
            _curDialogue++;
        }
    }

    public void TenthDialogue()
    {
        if (_curDialogue == 9 && _curRoom == 8)
        {
            dialogueController.StartDialogue(tutorialDialog);
            _curDialogue++;
        }
    }

    public void EighthHint()
    {
        if (_curHintId == 11 && _curRoom == 8)
        {
            hintContrller.StartHint();
            _curHintId++;
        }
    }

    public void EleventhDialogue()
    {
        if (_curDialogue == 10 && _curRoom == 8)
        {
            dialogueController.StartDialogue(tutorialDialog);
            _curDialogue++;
        }
    }
}
