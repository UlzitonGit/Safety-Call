using Source.Creatures.Health;
using UnityEngine;

public class PlayerHealth : CreatureHealth
{
    [SerializeField] private PlayerUiDrawer _playerUiDrawer;
    protected override void Start()
    {
        base.Start();
    }

    public override void GetDamage(float damage, Vector3 enemyPos)
    {
        base.GetDamage(damage, enemyPos);
        _playerUiDrawer.UpdateUI(_currentHealth);
    }

    protected override void Death()
    {
        base.Death();
        _gameplayStagesManager.PlayerKilled();
        _creaturesData._playerState.SetAlive(_isAlive);
    }
}
