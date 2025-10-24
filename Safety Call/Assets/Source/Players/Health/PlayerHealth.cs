using Source.Creatures.Health;
using UnityEngine;

public class PlayerHealth : CreatureHealth
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Death()
    {
        base.Death();
        _gameplayStagesManager.PlayerKilled();
        _creaturesData._playerState.SetAlive(_isAlive);
    }
}
