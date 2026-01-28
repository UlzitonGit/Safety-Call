using UnityEngine;

public class RPGShoot : AbilityBase
{
    [SerializeField] private RPGRocket _projectile;
    [SerializeField] private Transform _projectileSpawn;
    
    public override void UseAbility()
    {
        if(_usageCount == 0 || !CanBeUsed) return;
        _usageCount -= 1;
        Instantiate(_projectile, _projectileSpawn.position, _projectileSpawn.localRotation);
        StartCoroutine(Reloading());
    }
    
}
