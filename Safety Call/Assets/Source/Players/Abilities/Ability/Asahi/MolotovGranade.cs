using System;
using UnityEngine;

public class MolotovGranade : AbilityBase
{
    [SerializeField] private GranadeAbstract _granade;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private LayerMask _obstacles;
    private bool showHint;
    public override void UseAbility()
    {
        if(_usageCount == 0 || !CanBeUsed) return;
        _usageCount -= 1;
        GranadeAbstract _currentGranade = Instantiate(_granade, _spawnPoint.position, _spawnPoint.localRotation);
        _currentGranade.Throw();
    }
    public override void ShowHint()
    {
        showHint = true;
        _hint.SetActive(true);
    }

    public override void Cancel()
    {
        showHint = false;
        _hint.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (showHint)
        {
            Vector2 direction = _spawnPoint.up.normalized;
            
            RaycastHit2D hit = Physics2D.Raycast(_spawnPoint.position, direction, 100, _obstacles);
            Debug.DrawRay(_spawnPoint.position, direction * 10f, Color.red, 1);
            _hint.transform.position = hit.point;
        }
    }
}
