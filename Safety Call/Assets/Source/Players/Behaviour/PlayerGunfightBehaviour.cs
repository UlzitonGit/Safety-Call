using Source.Players.Behaviour;
using UnityEngine;

public class PlayerGunfightBehaviour : GunfightBehaviourManager
{
    
    [SerializeField] private bool _canShootFirst;

    public bool _isControlling;
    
    protected override bool CheckShootingRelevation()
    {
        if (_isControlling) return false;
        return _canShootFirst;
    }
}
