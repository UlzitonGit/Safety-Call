using UnityEngine;

public class DestroyableObjects : MonoBehaviour, IDamagable
{
    [SerializeField] private float health;

    [SerializeField] private GameObject _deathVFX;
    
    public void GetDamage(float damage, Vector3 enemyPos)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(_deathVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
