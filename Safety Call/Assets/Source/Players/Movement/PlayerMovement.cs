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

        private void FixedUpdate()
        {
            UpdatePathLine();
        }

        public void UpdatePathLine()
        {
            if (_agent.hasPath)
            {
                _lineRenderer.UpdateLineRenderer(_agent.path);
            }
        }
    }
}
