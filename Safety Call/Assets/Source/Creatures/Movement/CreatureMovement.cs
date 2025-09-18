using UnityEngine;
using UnityEngine.AI;

namespace Source.Creatures.Movement
{
    public abstract class CreatureMovement : MonoBehaviour
    {
        [SerializeField] protected Transform _aimPoint;
        
        [SerializeField] protected float _rotationSpeed = 5;
        [SerializeField] protected float _angleOffset;
        
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
        public virtual void LookAtPosition(Vector3 targetPosition)
        {
            //print(targetPosition);
            Vector3 direction = targetPosition - _aimPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            angle += _angleOffset;
            
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _aimPoint.rotation = Quaternion.Slerp(_aimPoint.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            
        }
    }
}
