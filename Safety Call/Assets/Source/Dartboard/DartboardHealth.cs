using Source.Creatures.Health;
using UnityEngine;

public class DartboardHealth : CreatureHealth
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Death()
    {
        return;
    }
}

