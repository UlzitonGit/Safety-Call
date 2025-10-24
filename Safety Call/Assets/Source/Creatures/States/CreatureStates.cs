using System;
using Source.Creatures.Movement;
using Source.Players.Behaviour;
using UnityEngine;

public class CreatureStates : MonoBehaviour
{
    public bool IsVisible { get; private set; }
    public bool IsAlive { get; private set; }
    public bool IsStunned { get; private set; }
    
    public bool CanMove  {get; private set;}
    
   [SerializeField] protected CreaturesData _data;
    
   
    

    private void Start()
    {
        IsAlive = true;
        CanMove = true;
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
        CanMove = alive;
        _data._FieldOfView.SetIsAbleToSee(alive);
        _data._playerGunfight.SetIsAbleToShoot(alive);
    }

    public virtual void SetStunned(bool stunned)
    {
        IsStunned = stunned;
    }

    public void SetCanMove(bool canMove)
    {
        CanMove = canMove;
    }
}
