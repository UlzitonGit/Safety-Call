using UnityEngine;

public class TrapsVisibility : MonoBehaviour, IPlayerSpotable
{
    public bool IsVisible;
   
    [SerializeField] private GameObject _meshRenderer;
    Coroutine _hideCoroutine;
    
   
    private float _timeToHide;
   

    private void Start()
    {
        HideEnemy();
    }

    private void Update()
    {
        if (_timeToHide > 0)
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
        print("Show");
        IsVisible = true;
        _meshRenderer.SetActive(true);
        _timeToHide = 0.4f;
    }

    public void HideEnemy()
    {
        _meshRenderer.SetActive(false);
        IsVisible = false;
    }

}
