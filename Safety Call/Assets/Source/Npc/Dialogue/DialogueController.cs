using Source.Core;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialoguesDataSO dialoguesData;
    [SerializeField] private GameObject playerBubble;
    [SerializeField] private GameObject npcBubble;
    [SerializeField] private TextMeshProUGUI playerText;
    [SerializeField] private TextMeshProUGUI npcText;
    [SerializeField] private GameObject exclamationMark;

    private AnimatedText _curAnimatedText;
    private DialogueData _curDialogue;
    private int _curPhraseIndex = 0;
    private bool _haveDialogue = true;

    private InputAction _nextAction;
    private InputAction _exitAction;

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
        if (_curAnimatedText == null)
            return;
        if (_curAnimatedText.IsPrinted)
        {
            _curPhraseIndex++;
            ShowPhrase();
        }
        else
        {
            _curAnimatedText.StopPrintText();
        }
    }
    private void DoExit(InputAction.CallbackContext ctx)
    {
        ExitDialogue();
    }

    public bool GetHaveDialogues()
    {
        int sum = 0;
        for (int i = 0; i < dialoguesData.DialogueData.Count; i++)
        {
            if (dialoguesData.DialogueData[i].AlreadyBeen)
                sum++;
        }
        if (sum == dialoguesData.DialogueData.Count)
            return false;
        return true;
    }

    public void ChooseDialogue()
    {
        for (int i = 0; i < dialoguesData.DialogueData.Count; i++)
        {
            if (!dialoguesData.DialogueData[i].AlreadyBeen)
            {
                _curDialogue = dialoguesData.DialogueData[i];
                exclamationMark.SetActive(false);
                ShowPhrase();
                return;
            }
        }
        ExitDialogue();
        return;
    }

    private void ExitDialogue()
    {
        _curPhraseIndex = 0;
        playerBubble.SetActive(false);
        npcBubble.SetActive(false);
        InputManager.Instance.SwitchActionMapType(ActionMapType.HubController);
        if (dialoguesData.DialogueData[dialoguesData.DialogueData.Count-1].AlreadyBeen)
            _haveDialogue = false;
        exclamationMark.SetActive(_haveDialogue);
    }

    private void ShowPhrase()
    {
        if (_curPhraseIndex < _curDialogue.Phrase.Count)
        {
            if (_curDialogue.Phrase[_curPhraseIndex].Talker == TalkerType.Player)
            {
                playerBubble.SetActive(true);
                npcBubble.SetActive(false);
                _curAnimatedText = playerText.GetComponent<AnimatedText>();
                _curAnimatedText.StartPrintText(_curDialogue.Phrase[_curPhraseIndex].Phrase);
            }
            else
            {
                npcBubble.SetActive(true);
                playerBubble.SetActive(false);
                _curAnimatedText = npcText.GetComponent<AnimatedText>();
                _curAnimatedText.StartPrintText(_curDialogue.Phrase[_curPhraseIndex].Phrase);
            }
        }
        else
        {
            _curDialogue.AlreadyBeen = true;
            ExitDialogue();
        }
    }
}
