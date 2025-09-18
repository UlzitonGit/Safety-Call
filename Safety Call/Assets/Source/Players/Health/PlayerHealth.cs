using Source.Creatures.Health;
using UnityEngine;

public class PlayerHealth : CreatureHealth
{
    private PlayerStates _playerStates;
    protected override void Start()
    {
        base.Start();
        _playerStates = GetComponent<PlayerStates>();
    }

    protected override void Death()
    {
        base.Death();
        _playerStates.SetAlive(_isAlive);
        Destroy(gameObject);
    }
}
