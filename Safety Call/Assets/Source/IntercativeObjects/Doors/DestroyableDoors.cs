using System.Collections;
using NavMeshPlus.Components;
using NavMeshPlus.Extensions;
using UnityEngine;
using UnityEngine.AI;

public class DestroyableDoors : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject m_Door;
    [SerializeField] private float health = 100f;
    [SerializeField] private NavMeshSurface _navMeshSurface;
    [SerializeField] private GameObject _deathVFX;
    [SerializeField] private bool isTutorial;
    public void GetDamage(float damage, Vector3 enemyPos)
    {
        if(health <= 0) return;
        health -= damage;
        if (health <= 0)
        {
            Instantiate(_deathVFX, transform.position, Quaternion.identity);
            m_Door.SetActive(false);
            _navMeshSurface.BuildNavMesh();
            if (isTutorial)
            {
                FindAnyObjectByType<TutorialController>().DestroyHints();
            }
        }
    }
    
}
