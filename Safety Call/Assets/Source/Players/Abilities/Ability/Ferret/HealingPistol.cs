using Source.Creatures.Health;
using UnityEngine;

public class HealingPistol : AbilityBase
{
    [SerializeField] private Transform _projectileSpawn;
    [SerializeField] private LayerMask _layersToIgnore;
    [SerializeField] private ParticleSystem _particleSystem;
    public override void UseAbility()
    {
        if(_usageCount == 0 || !CanBeUsed) return;
        _usageCount -= 1;
            
        Vector2 direction = _projectileSpawn.up.normalized;
            
        RaycastHit2D hit = Physics2D.Raycast(_projectileSpawn.position, direction, 100, ~_layersToIgnore);
        _particleSystem.Play();
        if (hit.transform.TryGetComponent<CreatureHealth>(out CreatureHealth health))
        {
            health.AddHealth(25f);
        }
        Debug.DrawRay(_projectileSpawn.position, direction * 10f, Color.red, 1);
        print("healing");
        
        StartCoroutine(Reloading());
    }

    public void AddUsages(int amount)
    {
        _usageCount += amount;
    }
    public override void ShowHint()
    {
        _hint.SetActive(true);
    }

    public override void Cancel()
    {
        _hint.SetActive(false);
    }
}
