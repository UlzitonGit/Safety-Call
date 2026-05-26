using UnityEngine;

public class RPGShoot : AbilityBase
{
    [SerializeField] private RPGRocket _projectile;
    [SerializeField] private Transform _projectileSpawn;
    [SerializeField] private LayerMask _obstacles;
    private bool showHint;
    public override void UseAbility()
    {
        if(_usageCount == 0 || !CanBeUsed) return;
        _usageCount -= 1;
        Instantiate(_projectile, _projectileSpawn.position, _projectileSpawn.localRotation);
        _hint.SetActive(false);
        StartCoroutine(Reloading());
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

    private void FixedUpdate()
    {
        if (showHint)
        {
            Vector2 direction = _projectileSpawn.up.normalized;
            
            RaycastHit2D hit = Physics2D.Raycast(_projectileSpawn.position, direction, 100, _obstacles);
            print(hit.collider.gameObject.name);
            Debug.DrawRay(_projectileSpawn.position, direction * 10f, Color.red, 1);
            _hint.transform.position = hit.point;
        }
    }
}
