using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    private Vector3 _destination;
    private bool isActive;
    void Update()
    {
        transform.rotation = new Quaternion(0,0,0,1);
        if(isActive)
            _navMeshAgent.SetDestination(_destination);
    }

    public void SetDestination(Vector3 destination)
    {
        _destination = destination;
        isActive = true;
    }
}
