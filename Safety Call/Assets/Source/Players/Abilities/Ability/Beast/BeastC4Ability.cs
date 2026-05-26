using UnityEngine;

public class BeastC4Ability : AbilityBase
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _c4Prefab;

    private C4 _c4;
    private bool _isActive;
    public override void UseAbility()
    {
        if(_usageCount <= 0 || !CanBeUsed) return;
        if (!_isActive)
        {
           _c4 = Instantiate(_c4Prefab, _spawnPoint.position, Quaternion.identity).GetComponent<C4>();
        }
        else
        {
            _c4.Activate();
        }
        _isActive = !_isActive;
        StartCoroutine(Reloading());
    }
    public override void ShowHint()
    {
        _hint.SetActive(true);
    }

    public override void Cancel()
    {
        _hint.SetActive(false);
    }
}
