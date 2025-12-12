using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class NpcDialogue : MonoBehaviour
{
    [SerializeField] private GameObject hint;
    [SerializeField] private GameObject exclamationMark;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private DialoguesDataSO dialoguesDataSO;
    private NpcRandomPhrase _npsRandomPhrase;
    private bool _canTalk = false;

    private InputAction _dialogueAction;

    private void OnEnable()
    {
        _dialogueAction = InputManager.Instance.GameInput.Hub.Dialogue;
        _dialogueAction.performed += DoTalk;
    }

    private void Start()
    {
        print("start");
        _npsRandomPhrase = GetComponent<NpcRandomPhrase>();
        exclamationMark.SetActive(GetHaveDialogues());
    }

    private void OnDisable()
    {
        _dialogueAction.performed -= DoTalk;
    }

    private void DoTalk(InputAction.CallbackContext ctx)
    {
        if (_canTalk)
        {
            hint.SetActive(false);
            _npsRandomPhrase.InDialogue = true;
            dialogueController.StartDialogue(dialoguesDataSO);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GetHaveDialogues())
        {
            exclamationMark.SetActive(false);
            hint.SetActive(true);
            _canTalk = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!dialogueController.InDialogue)
        {
            if (collision.CompareTag("Player") && GetHaveDialogues())
            {
                hint.SetActive(true);
                _canTalk = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hint.SetActive(false);
            _canTalk = false;
            if (GetHaveDialogues())
            {
                exclamationMark.SetActive(true);
            }
        }
    }

    private bool GetHaveDialogues()
    {
        for (int i = 0; i < dialoguesDataSO.DialogueData.Count; i++)
        {
            if (dialoguesDataSO.DialogueData[i].Level == PlayerPrefs.GetInt("CurLevel"))
            {
                if (dialoguesDataSO.DialogueData[i].AlreadyBeen)
                    return false;
            }
            
        }   
        return true;
    }
}
