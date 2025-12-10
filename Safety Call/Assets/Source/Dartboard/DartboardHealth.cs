using Source.Creatures.Health;
using UnityEngine;

public class DartboardHealth : CreatureHealth
{
    [SerializeField] private Animator _dartAnim;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Death()
    {
        _creaturesData._playerState.SetAlive(false);
        _dartAnim.SetTrigger("Death");
        return;
    }
}

