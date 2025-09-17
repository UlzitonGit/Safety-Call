using System;
using Source.Creatures.Movement;
using UnityEngine;

namespace Source.Players.Movement
{
    public class PlayerMovement : CreatureMovement
    {
        [SerializeField] private Transform _playerAimPoint;
        [SerializeField] private LinePathController _lineRenderer;
        [SerializeField] private float _rotationSpeed = 5;
        [SerializeField] private float _angleOffset;
        private Vector3 _target;
        public override void MoveOnTarget(Vector3 target)
        {
            base.MoveOnTarget(target);
        }

        public void LookAtTarget(Vector3 target)
        {
            _target = target;
        }

        private void FixedUpdate()
        {
            UpdatePathLine();
            LookAtPosition(_target);
        }

        public void UpdatePathLine()
        {
            if (_agent.hasPath)
            {
                _lineRenderer.UpdateLineRenderer(_agent.path);
            }
        }
        public void LookAtPosition(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - _playerAimPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            angle += _angleOffset;
            
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _playerAimPoint.rotation = Quaternion.Slerp(_playerAimPoint.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            
        }
    }
}
