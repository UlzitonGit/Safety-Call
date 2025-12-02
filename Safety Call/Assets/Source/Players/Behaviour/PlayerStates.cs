using UnityEngine;

public class PlayerStates : CreatureStates
{
    [SerializeField] private PlayerData _playerData;
    
    public override void SetAlive(bool alive)
    {
        base.SetAlive(alive);
        _playerData._FieldOfView.SetIsAbleToSee(alive);
        _playerData._PlayerGunfightBehaviour.SetIsAbleToShoot(alive);
    }
}
