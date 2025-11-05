using System.Collections.Generic;
using Source.Core;
using Source.Players.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Players.Controls
{
    public class PlayerTacticalControlInput : MonoBehaviour
    {
        private List<PlayerMovement> _playerMovement;
        private InputAction _moveAction;
        private InputAction _turnAction;

        private void OnEnable()
        {
            _moveAction = InputManager.Instance.GameInput.TacticalMove.Move;
            _turnAction = InputManager.Instance.GameInput.TacticalMove.Turn;

            _moveAction.performed += DoMove;
            _turnAction.performed += DoTurn;
        }

        private void OnDisable()
        {
            _moveAction.performed -= DoMove;
            _turnAction.performed -= DoTurn;
        }

        private void DoMove(InputAction.CallbackContext ctx)
        {
            MakePlayerMove(GetClickCoordinates());
        }

        private void DoTurn(InputAction.CallbackContext ctx)
        {
            MakePlayerAim(GetClickCoordinates());
        }

        public void SetPlayerMovement(List<PlayerMovement> playerMovement)
        {
            _playerMovement = new List<PlayerMovement>();
            _playerMovement = playerMovement;
        }

        private Vector3 GetClickCoordinates()
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), 1));
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
