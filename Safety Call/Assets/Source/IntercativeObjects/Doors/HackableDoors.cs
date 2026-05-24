using NavMeshPlus.Components;
using UnityEngine;

public class HackableDoors : MonoBehaviour, IHackable
{
    [SerializeField] private NavMeshSurface _navMeshSurface;

    public void Hack()
    {
        gameObject.SetActive(false);
        _navMeshSurface.BuildNavMesh();
    }
}
