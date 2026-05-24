using NavMeshPlus.Components;
using NavMeshPlus.Extensions;
using UnityEngine;
using UnityEngine.AI;

public class DestroyableDoors : MonoBehaviour, IDamagable
{
    [SerializeField] private float health;
    [SerializeField] private NavMeshSurface _navMeshSurface;
    [SerializeField] private GameObject _deathVFX;
    
    public void GetDamage(float damage, Vector3 enemyPos)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(_deathVFX, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            if (_navMeshSurface != null)
            {
                _navMeshSurface.BuildNavMesh();
            }
        }
    }
}
