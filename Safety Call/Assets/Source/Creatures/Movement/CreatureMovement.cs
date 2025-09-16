using UnityEngine;
using UnityEngine.AI;

namespace Source.Creatures.Movement
{
    public abstract class CreatureMovement : MonoBehaviour
    {
        protected NavMeshAgent _agent;
        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            transform.rotation = new Quaternion(0,0,0,1);
        }

        public virtual void MoveOnTarget(Vector3 target)
        {
            _agent.SetDestination(target);
        }
    }
}
