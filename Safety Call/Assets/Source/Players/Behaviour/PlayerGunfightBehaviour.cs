using Source.Players.Behaviour;
using UnityEngine;

public class PlayerGunfightBehaviour : GunfightBehaviourManager
{
    [SerializeField] private bool _canShootFirst;
    protected override bool CheckShootingRelevation()
    {
        return _canShootFirst;
    }
}
