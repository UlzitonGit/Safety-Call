using Source.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HintContrller : MonoBehaviour
{
    public UnityEvent SecondHintEvent;
    [SerializeField] private GameObject HintPanel;
    [SerializeField] private Image HintImage;
    [SerializeField] private TextMeshProUGUI HintText;
    [SerializeField] private TutorialHintSO tutorialHintSO;
    private InputAction _hideHintAction;
    private int _curHint = 0;

    private void OnEnable()
    {
        _hideHintAction = InputManager.Instance.GameInput.UI.Exit;
        _hideHintAction.performed += HideHint;
    }

    private void OnDisable()
    {
        _hideHintAction.performed -= HideHint;
    }
    public void ShowHint()
    {
        InputManager.Instance.SwitchActionMapType(ActionMapType.UI);
        HintPanel.SetActive(true);
        HintImage.sprite = tutorialHintSO.tutorialHints[_curHint].HintSprite;
        HintText.text = tutorialHintSO.tutorialHints[_curHint].HintText;
    }

    public void HideHint(InputAction.CallbackContext ctx)
    {
        HintPanel.SetActive(false);
        InputManager.Instance.SwitchActionMapType(ActionMapType.MissionController);
        if (_curHint == 0)
        {
            SecondHintEvent?.Invoke();
        }
        _curHint++;
    }
    public void HideHint()
    {
        HintPanel.SetActive(false);
        InputManager.Instance.SwitchActionMapType(ActionMapType.MissionController);
        if (_curHint == 0)
        {
            SecondHintEvent?.Invoke();
        }
        _curHint++;
    }
}
