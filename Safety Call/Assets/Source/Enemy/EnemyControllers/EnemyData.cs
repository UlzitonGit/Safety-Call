using Source.Players.Behaviour;
using UnityEngine;

public class EnemyData : CreaturesData
{
    [SerializeField] public FieldOfView _FieldOfView;
    [SerializeField] public GunfightBehaviourManager _playerGunfight;
}
