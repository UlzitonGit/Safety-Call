using UnityEngine;
using UnityEngine.AI;

namespace Source.Creatures.Movement
{
    public abstract class CreatureMovement : MonoBehaviour
    {
        [SerializeField] protected Transform _aimPoint;
        
        [SerializeField] protected float _rotationSpeed = 5;
        [SerializeField] protected float _angleOffset;
        
        protected Vector3 _target;
        
        protected NavMeshAgent _agent;

        protected bool _canMove = true;
        
        protected Vector3 _currentTarget;
        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            transform.rotation = new Quaternion(0,0,0,1);
        }
        public virtual void LookAtTarget(Vector3 target)
        {
            if(!_canMove) return;
            _target = target;
        }
        public virtual void MoveOnTarget(Vector3 target)
        {
            if(!_canMove) return;
            if(target == null) return;
            _currentTarget = target;
            _agent.SetDestination(_currentTarget);
        }
        protected virtual void LookAtPosition()
        {
            if(!_canMove) return;
            //print(targetPosition);
            Vector3 direction = _target - _aimPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            angle += _angleOffset;
            
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _aimPoint.rotation = Quaternion.Slerp(_aimPoint.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }

        public virtual float  GetHorizontalSpeed()
        {
            return _agent.velocity.x;
        }
        public virtual float  GetVerticalSpeed()
        {
            return _agent.velocity.y;
        }
        public virtual float  GetSpeed()
        {
            return _agent.velocity.magnitude;
        }

        public NavMeshPath GetPath()
        {
            return _agent.path;
        }

        public void SetCanMove(bool canMove)
        {
            _canMove = canMove;
            if (!_canMove) _agent.Stop();
        }
    }
}
