using Source.Creatures.Health;
using UnityEngine;

public class HealingPistol : AbilityBase
{
    [SerializeField] private Transform _projectileSpawn;
    [SerializeField] private LayerMask _layersToIgnore;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private LayerMask _obstacles;
    
    private bool showHint;
    
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
    private void FixedUpdate()
    {
        if (showHint)
        {
            Vector2 direction = _projectileSpawn.up.normalized;
            
            RaycastHit2D hit = Physics2D.Raycast(_projectileSpawn.position, direction, 100, _obstacles);
            Debug.DrawRay(_projectileSpawn.position, direction * 10f, Color.red, 1);
            _hint.transform.position = hit.point;
        }
    }

    public void AddUsages(int amount)
    {
        _usageCount += amount;
    }
    public override void ShowHint()
    {
        showHint = true;
        _hint.SetActive(true);
    }

    public override void Cancel()
    {
        showHint = false;
        _hint.SetActive(false);
    }
}
