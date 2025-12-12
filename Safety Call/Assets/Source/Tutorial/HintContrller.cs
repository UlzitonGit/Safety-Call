using Source.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HintContrller : MonoBehaviour
{
    public UnityEvent AfterHintEvent;
    [SerializeField] private GameObject hintPanel;
    [SerializeField] private Image hintImage;
    [SerializeField] private TextMeshProUGUI hintText;
    [SerializeField] private Button nextHintButton;
    [SerializeField] private TutorialHintSO tutorialHintSO;
    private InputAction _hideHintAction;
    private InputAction _nextHintAction;
    private int _curHint = 0;
    private ActionMapType _curActionMap;
    private TutorialHintPage _curHintPages;

    private void OnEnable()
    {
        foreach(TutorialHintPage hint in tutorialHintSO.TutorialHintsPages)
        {
            hint.AlreadyBeen = false;
        }
        _hideHintAction = InputManager.Instance.GameInput.Hint.Exit;
        _nextHintAction = InputManager.Instance.GameInput.Hint.Next;
        _hideHintAction.performed += DoHideHint;
        _nextHintAction.performed += DoNextHint;
    }

    private void OnDisable()
    {
        _hideHintAction.performed -= DoHideHint;
        _nextHintAction.performed -= DoNextHint;
    }

    public void StartHint()
    {
        _curActionMap = InputManager.Instance.CurentActionMapType;
        InputManager.Instance.SwitchActionMapType(ActionMapType.Hint);
        hintPanel.SetActive(true);
        ChooseHint();
    }

    private void ChooseHint()
    {
        for (int i = 0; i < tutorialHintSO.TutorialHintsPages.Count; i++)
        {
            if (!tutorialHintSO.TutorialHintsPages[i].AlreadyBeen)
            {
                _curHintPages = tutorialHintSO.TutorialHintsPages[i];
                ShowHint();
                if (_curHintPages.TutorialHints.Count > 1) 
                    nextHintButton.gameObject.SetActive(true);
                return;
            }
        }
    }

    private void ShowHint()
    {
        if (_curHint < _curHintPages.TutorialHints.Count)
        {
            hintImage.sprite = _curHintPages.TutorialHints[_curHint].HintSprite;
            hintText.text = _curHintPages.TutorialHints[_curHint].HintText;
            if (_curHint == _curHintPages.TutorialHints.Count-1)
                nextHintButton.gameObject.SetActive(false);
        }
        else
        {
            _curHintPages.AlreadyBeen = true;
            Hide();
        }
    }

    private void DoNextHint(InputAction.CallbackContext ctx)
    {
        if (_curHint >= _curHintPages.TutorialHints.Count)
            return;
        Next();
    }

    public void Next()
    {
        _curHint++;
        ShowHint();
    }

    private void DoHideHint(InputAction.CallbackContext ctx)
    { 
        Hide();
    }

    public void HideHint()
    {
        Hide();
    }

    private void Hide()
    {
        _curHintPages.AlreadyBeen = true;
        hintPanel.SetActive(false);
        nextHintButton.gameObject.SetActive(false);
        InputManager.Instance.SwitchActionMapType(_curActionMap);
        _curHint = 0;
        AfterHintEvent?.Invoke();
    }
}
