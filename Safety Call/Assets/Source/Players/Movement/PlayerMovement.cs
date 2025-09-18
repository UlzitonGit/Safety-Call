using System;
using Source.Creatures.Movement;
using UnityEngine;

namespace Source.Players.Movement
{
    public class PlayerMovement : CreatureMovement
    {
        [SerializeField] private LinePathController _lineRenderer;
        
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

        public override void LookAtPosition(Vector3 targetPosition)
        {
            base.LookAtPosition(targetPosition);
        }
    }
}
