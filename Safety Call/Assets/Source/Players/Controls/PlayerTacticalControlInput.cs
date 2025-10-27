using System.Collections.Generic;
using Source.Creatures.Movement;
using Source.Players.Movement;
using UnityEngine;

namespace Source.Players.Controls
{
    public class PlayerTacticalControlInput : MonoBehaviour
    {
        private List<PlayerMovement> _playerMovement;
        
        private void Update()
        {
            if (Input.GetButtonDown("Fire2"))
            {
                MakePlayerMove(GetClickCoordinates());
            }
            if (Input.GetButtonDown("Fire1"))
            {
                MakePlayerAim(GetClickCoordinates());
            }
        
        }

        public void SetPlayerMovement(List<PlayerMovement> playerMovement)
        {
            _playerMovement = new List<PlayerMovement>();
            _playerMovement = playerMovement;
        }

        private Vector3 GetClickCoordinates()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            //if(hit2D.transform.gameObject.layer == LayerMask.NameToLayer("UI")) return default;
            if (hit2D.collider != null)
            {
                return hit2D.point;
            }

            return default;
        }
        private void MakePlayerMove(Vector3 position)
        {
            if(_playerMovement == null) return;
            for (int i = 0; i < _playerMovement.Count; i++)
            {
                _playerMovement[i].UpdatePathLine();
                _playerMovement[i].MoveOnTarget(position);
            }
        }
        private void MakePlayerAim(Vector3 target)
        {
            if(_playerMovement == null) return;
            print("look");
            for (int i = 0; i < _playerMovement.Count; i++)
            {
                _playerMovement[i].LookAtTarget(target);
            }
        }
    }
}
