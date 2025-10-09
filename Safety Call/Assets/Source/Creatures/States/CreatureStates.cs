using System;
using Source.Creatures.Movement;
using Source.Players.Behaviour;
using UnityEngine;

public class CreatureStates : MonoBehaviour
{
    public bool IsVisible { get; private set; }
    public bool IsAlive { get; private set; }
    
   [SerializeField] protected CreatureMovement _movement;
    
   [SerializeField]  protected GunfightBehaviourManager _creatureGunfight;
    
   [SerializeField]  protected FieldOfView _creatureFieldOfView;
    

    private void Start()
    {
        IsAlive = true;
        //_movement = GetComponent<CreatureMovement>();
        //_creatureGunfight = GetComponent<PlayerGunfightBehaviour>();
        //_creatureFieldOfView = GetComponentInChildren<FieldOfView>();
    }

    public virtual void SetVisible(bool visible)
    {
        IsVisible = visible;
    }

    public virtual void SetAlive(bool alive)
    {
        IsAlive = alive;
        _movement.SetCanMove(alive);
        _creatureFieldOfView.SetIsAbleToSee(alive);
        _creatureGunfight.SetIsAbleToShoot(alive);
    }
}
