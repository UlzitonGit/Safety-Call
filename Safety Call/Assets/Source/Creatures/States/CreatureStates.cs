using System;
using UnityEngine;

public class CreatureStates : MonoBehaviour
{
    public bool IsVisible { get; private set; }
    public bool IsAlive { get; private set; }

    private void Start()
    {
        IsAlive = true;
    }

    public virtual void SetVisible(bool visible)
    {
        IsVisible = visible;
    }

    public virtual void SetAlive(bool alive)
    {
        IsAlive = alive;
    }
}
