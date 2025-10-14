using UnityEngine;

public class PlayerVisibility : MonoBehaviour
{
    public bool IsVisible;
    
    Coroutine _hideCoroutine;

    private PlayerStates _playerStates;
   
    private float _timeToHide;

    private void Start()
    {
        _playerStates = GetComponent<PlayerStates>();
        HideEnemy();
    }

    private void Update()
    {
        if (_timeToHide > 0 && _playerStates.IsVisible)
        {
            _timeToHide -= Time.deltaTime;
        }
        else if (_timeToHide <= 0)
        {
            HideEnemy();
        }
    }

    public void ShowEnemy()
    {
        IsVisible = true;
        _playerStates.SetVisible(IsVisible);
        _timeToHide = 0.4f;
    }

    public void HideEnemy()
    {
        IsVisible = false;
        _playerStates.SetVisible(IsVisible);
    }

}
