using System.Collections;
using Source.Creatures.Health;
using Source.Players.Movement;
using UnityEngine;

public class PlayerHealth : CreatureHealth
{
    [SerializeField] private PlayerUiDrawer _playerUiDrawer;

    private bool _isRevived;
    protected override void Start()
    {
        base.Start();
    }

    public override void GetDamage(float damage, Vector3 enemyPos)
    {
        base.GetDamage(damage, enemyPos);
        StartCoroutine(LookAtTarget(enemyPos));
        _playerUiDrawer.UpdateUI(_currentHealth);
    }
    IEnumerator LookAtTarget(Vector3 enemyPos)
    {
        yield return new WaitForSeconds(_timeToReaction);
        _creaturesData._playerMovement.LookAtTarget(enemyPos);
    }

    public void AddHealth(float health)
    {
        _currentHealth += health;
        print(_currentHealth);
        _playerUiDrawer.UpdateUI(_currentHealth);
    }

    public void Revive()
    {
        _currentHealth = 0;
        _creaturesData._playerState.SetCanMove(true);
        _creaturesData._playerState.SetAlive(true);
        _creaturesData._playerMovement.GetComponent<PlayerMovement>().StopAgent(false);
        
        _isRevived = true;
        _playerAnimator.Revive();
        AddHealth(40f);
        _capsuleCollider2D.enabled = true;
        _isAlive = true;
    }

    protected override void Death()
    {
        base.Death();
        _playerAnimator.Death();
        _creaturesData._playerState.SetAlive(_isAlive);
        _gameplayStagesManager.PlayerKilled();
    }

    public bool GetIsRevived()
    {
        return _isRevived;
    }

    public PlayerUiDrawer GetPlayerUiDrawer()
    {
        return _playerUiDrawer;
    }
}
