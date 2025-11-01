using System;
using System.Collections.Generic;
using UnityEngine;

public class CCTVFOV : MonoBehaviour, IHackable
{
    [SerializeField] private GameObject _activationLightGameObject;
    
    [SerializeField] private bool _isActive;
    
    private List<IPlayerSpotable> _enemyVisibilities = new List<IPlayerSpotable>();

    private bool _hasInSeeZone;

    private void Update()
    {
        if (_isActive && _hasInSeeZone)
        {
            foreach (var enemy in _enemyVisibilities)
            {
                enemy.ShowEnemy();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            IPlayerSpotable enemy;
            other.TryGetComponent<IPlayerSpotable>(out enemy);
            _enemyVisibilities.Add(enemy);
            _hasInSeeZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            IPlayerSpotable enemy;
            other.TryGetComponent<IPlayerSpotable>(out enemy);
            if (_enemyVisibilities.Contains(enemy))
                _enemyVisibilities.Remove(enemy);
            if(_enemyVisibilities.Count == 0) _hasInSeeZone = false;
        }
    }

    public void Hack()
    {
        _isActive = true;
        _activationLightGameObject.SetActive(true);
    }
}
