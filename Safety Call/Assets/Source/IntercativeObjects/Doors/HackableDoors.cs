using NavMeshPlus.Components;
using UnityEngine;

public class HackableDoors : MonoBehaviour, IHackable
{
    [SerializeField] private NavMeshSurface _navMeshSurface;
    [SerializeField] private GameObject _hacked;

    public void Hack()
    {
        _hacked.SetActive(true);
        gameObject.SetActive(false);
        _navMeshSurface.BuildNavMesh();
    }
}
