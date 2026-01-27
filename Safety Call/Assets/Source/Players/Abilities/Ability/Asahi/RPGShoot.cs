using UnityEngine;

public class RPGShoot : AbilityBase
{
    [SerializeField] private RPGRocket _projectile;
    [SerializeField] private Transform _projectileSpawn;
    
    public override void UseAbility()
    {
        Instantiate(_projectile, _projectileSpawn.position, _projectileSpawn.localRotation);
        StartCoroutine(Reloading());
    }
    
}
