using UnityEngine;

public class CreatureStates : MonoBehaviour
{
    public bool IsVisible { get; private set; }
    public bool IsAlive { get; private set; }

    public virtual void SetVisible(bool visible)
    {
        IsVisible = visible;
    }

    public virtual void SetAlive(bool alive)
    {
        IsAlive = alive;
    }
}
