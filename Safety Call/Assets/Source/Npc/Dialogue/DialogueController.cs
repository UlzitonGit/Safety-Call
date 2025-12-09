using Source.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public bool InDialogue { get; private set; } = false;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI nameCharText;
    [SerializeField] private Image charIcon;
    [SerializeField] private AnimatedText animatedText;
    [SerializeField] private bool _inHub;
    private DialoguesDataSO _dialoguesData;
    private DialogueData _curDialogue;
    private int _curPhraseIndex = 0;

    private InputAction _nextAction;
    private InputAction _exitAction;
    public UnityEvent DialogueEndEvent;

    private void OnEnable()
    {
        _nextAction = InputManager.Instance.GameInput.Dialogue.Next;
        _exitAction = InputManager.Instance.GameInput.Dialogue.HubController;

        _nextAction.performed += DoNext;
        _exitAction.performed += DoExit;
    }

    private void OnDisable()
    {
        _nextAction.performed -= DoNext;
        _exitAction.performed -= DoExit;
    }

    private void DoNext(InputAction.CallbackContext ctx)
    {
        if (animatedText == null)
            return;
        if (animatedText.IsPrinted)
        {
            _curPhraseIndex++;
            ShowPhrase();
        }
        else
        {
            animatedText.StopPrintText();
        }
    }
    private void DoExit(InputAction.CallbackContext ctx)
    {
        ExitDialogue();
    }

    public void StartDialogue(DialoguesDataSO dialoguesData)
    {
        InputManager.Instance.SwitchActionMapType(ActionMapType.Dialogue);
        _dialoguesData  = dialoguesData;
        InDialogue = true;
        dialoguePanel.SetActive(true);
        ChooseDialogue();
    }

    public bool GetInDialogue()
    {
        return InDialogue;
    }

    private void ChooseDialogue()
    {
        for (int i = 0; i < _dialoguesData.DialogueData.Count; i++)
        {
            if (!_dialoguesData.DialogueData[i].AlreadyBeen)
            {
                _curDialogue = _dialoguesData.DialogueData[i];
                ShowPhrase();
                return;
            }
        }
        ExitDialogue();
        return;
    }

    private void ShowPhrase()
    {
        if (_curPhraseIndex < _curDialogue.Phrase.Count)
        {
            nameCharText.text = _curDialogue.Phrase[_curPhraseIndex].Talker.ToString();
            charIcon.sprite = _curDialogue.Phrase[_curPhraseIndex].CharacterIcon;
            animatedText.StartPrintText(_curDialogue.Phrase[_curPhraseIndex].Phrase);
        }
        else
        {
            _curDialogue.AlreadyBeen = true;
            ExitDialogue();
        }
    }

    private void ExitDialogue()
    {
        _curPhraseIndex = 0;
        dialoguePanel.SetActive(false);
        if (_inHub)
            InputManager.Instance.SwitchActionMapType(ActionMapType.HubController);
        else
        {
            InputManager.Instance.SwitchActionMapType(ActionMapType.MissionController);
            DialogueEndEvent?.Invoke();
        }
            
        InDialogue = false;
    }
}
