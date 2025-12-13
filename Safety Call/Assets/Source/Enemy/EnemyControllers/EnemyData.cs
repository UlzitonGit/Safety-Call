using Source.Creatures.Health;
using Source.Creatures.Movement;
using Source.Enemy;
using Source.Players.Behaviour;
using UnityEngine;

public class EnemyData : CreaturesData
{
    [SerializeField] public FieldOfView _FieldOfView;
    [SerializeField] public GunfightBehaviourManager _enemyGunfight;
    [SerializeField] public PlayerSOReader _SoReader;
    [field:SerializeField ] public EnemyMovement _enemyMovement { get; private set; }
    [field:SerializeField] public EnemyStates _enemyState { get; private set; }
    [field:SerializeField] public EnemyHealth _enemyHealth { get; private set; }
}
