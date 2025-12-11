using UnityEngine;

public class TrapsVisibility : MonoBehaviour, IPlayerSpotable
{
    [Range(0.1f, 1)][SerializeField] private float spawnChance;
    public bool IsVisible;
   
    [SerializeField] private GameObject _meshRenderer;
    Coroutine _hideCoroutine;
    
   
    private float _timeToHide;
   

    private void Start()
    {
        if(Random.Range(0f, spawnChance) >= 0.25f) gameObject.SetActive(false);
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
