using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class NpsDialogue : MonoBehaviour
{
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private GameObject hint;

    private NpsRandomPhrase _npsRandomPhrase;
    private bool _canTalk = false;

    private InputAction _dialogueAction;

    private void OnEnable()
    {
        _dialogueAction = InputManager.Instance.GameInput.Hub.Dialogue;
        _dialogueAction.performed += DoTalk;
    }

    private void Start()
    {
        _npsRandomPhrase = GetComponent<NpsRandomPhrase>();
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
            InputManager.Instance.SwitchActionMapType(ActionMapType.Dialogue);
            _npsRandomPhrase.InDialogue = true;
            dialogueController.ChooseDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && dialogueController.GetHaveDialogues())
        {
            hint.SetActive(true);
            _canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hint.SetActive(false);
            _canTalk = false;
        }
    }
}
