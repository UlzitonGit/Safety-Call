using Source.Creatures.Health;
using Source.Creatures.Movement;
using Source.Players.Behaviour;
using UnityEngine;

public abstract class CreaturesData : MonoBehaviour
{
    [field:SerializeField ] public CreatureMovement _playerMovement { get; private set; }
    [field:SerializeField] public CreatureStates _playerState { get; private set; }
    [field:SerializeField] public CreatureHealth _playerHealth { get; private set; }
}
