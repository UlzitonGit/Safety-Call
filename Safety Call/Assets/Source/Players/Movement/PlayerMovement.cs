using System;
using Source.Creatures.Movement;
using UnityEngine;

namespace Source.Players.Movement
{
    public class PlayerMovement : CreatureMovement
    {
        [SerializeField] private LinePathController _lineRenderer;
        
        public override void MoveOnTarget(Vector3 target)
        {
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
            if (_agent.hasPath)
            {
                _lineRenderer.UpdateLineRenderer(_agent.path);
            }
        }

        protected override void LookAtPosition()
        {
            base.LookAtPosition();
        }
    }
}
