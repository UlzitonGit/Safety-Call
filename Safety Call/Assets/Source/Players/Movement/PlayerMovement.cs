using System;
using Source.Creatures.Movement;
using UnityEngine;

namespace Source.Players.Movement
{
    public class PlayerMovement : CreatureMovement
    {
        [SerializeField] private LinePathController _lineRenderer;
        
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private bool _isControlling;
        
        
        public override void MoveOnTarget(Vector3 target)
        {
            if (!_agent.enabled) return;
            base.MoveOnTarget(target);
        }

        protected void FixedUpdate()
        {
            LookAtPosition();
            UpdatePathLine();
        }
        

        public override void LookAtTarget(Vector3 target)
        {
            _target = target;
        }
        

        public void UpdatePathLine()
        {
            if (_agent.hasPath && _agent.enabled)
            {
                _lineRenderer.UpdateLineRenderer(_agent.path);
            }
        }

        protected override void LookAtPosition()
        {
            if (!_agent.enabled) return;
            base.LookAtPosition();
        }

        public void StopAgent(bool stop)
        {
            _agent.isStopped = stop;
            _rigidbody.isKinematic = !stop;
        }

        public void MoveSingle(Vector2 direction)
        {
            if(!_creatureStates.CanMove || _creatureStates.IsStunned) return;   
            _rigidbody.linearVelocity = direction * _agent.speed;
        }
    }
}
