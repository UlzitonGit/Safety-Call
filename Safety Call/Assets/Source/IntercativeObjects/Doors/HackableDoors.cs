using NavMeshPlus.Components;
using UnityEngine;

public class HackableDoors : MonoBehaviour, IHackable
{
    [SerializeField] private NavMeshSurface _navMeshSurface;
    [SerializeField] private GameObject _hacked;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Hack()
    {
        _hacked.SetActive(true);
        gameObject.SetActive(false);
        _spriteRenderer.color = Color.green;
        _navMeshSurface.BuildNavMesh();
    }
}
