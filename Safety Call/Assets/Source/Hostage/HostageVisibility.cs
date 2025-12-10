using UnityEngine;

public class HostageVisibility : MonoBehaviour, IPlayerSpotable
{
    public bool IsVisible;
   
    [SerializeField] private GameObject _meshRenderer;
    Coroutine _hideCoroutine;

    private CreatureStates _states;
   
    private float _timeToHide;
   

    private void Start()
    {
        _states = GetComponent<CreatureStates>();
        HideHostage();
    }

    private void Update()
    {
        if (_timeToHide > 0 && _states.IsAlive && IsVisible)
        {
            _timeToHide -= Time.deltaTime;
        }
        else if (_timeToHide <= 0 && _states.IsAlive)
        {
            HideHostage();
        }
    }

    public void ShowEnemy()
    {
        print("Show");
        IsVisible = true;
        _states.SetVisible(true);
        _meshRenderer.SetActive(true);
        _timeToHide = 0.4f;
    }

    private void HideHostage()
    {
        _meshRenderer.SetActive(false);
        _states.SetVisible(false);
        IsVisible = false;
    }

}
