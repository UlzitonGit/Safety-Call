using Source.Creatures.Movement;
using Source.Players.Movement;
using UnityEngine;

namespace Source.Players.Controls
{
    public class PlayerMoveInput : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
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

        public void SetPlayerMovement(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }

        private Vector3 GetClickCoordinates()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if(hit2D.transform.gameObject.layer == LayerMask.NameToLayer("UI")) return default;
            if (hit2D.collider != null)
            {
                return hit2D.point;
            }

            return default;
        }
        private void MakePlayerMove(Vector3 position)
        {
            if(_playerMovement == null) return;
            _playerMovement.UpdatePathLine();
            _playerMovement.MoveOnTarget(position);
        }
        private void MakePlayerAim(Vector3 target)
        {
            if(_playerMovement == null) return;
            print("look");
            _playerMovement.LookAtTarget(target);
        }
    }
}
