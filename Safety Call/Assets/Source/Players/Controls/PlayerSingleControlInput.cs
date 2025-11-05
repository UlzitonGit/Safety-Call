using Source.Core;
using Source.Players.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSingleControlInput : MonoBehaviour
{
    [SerializeField] public PlayerMovement _playerMovement;
    private InputAction _moveAction;
    private InputAction _turnAction;

    private void OnEnable()
    {
        _moveAction = InputManager.Instance.GameInput.IndividualMove.Move;
        _turnAction = InputManager.Instance.GameInput.IndividualMove.Turn;
    }

    void Update()
    {
        _playerMovement.MoveSingle(_moveAction.ReadValue<Vector2>());
        _playerMovement.LookAtTarget(GetClickCoordinates());
    }
    
    private void OnDisable()
    {
        _moveAction = null;
        _turnAction = null;
    }

    private Vector3 GetMousCoordinate()
    {
        return new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), 1);
    }

    public Vector3 GetClickCoordinates()
    {
        Ray ray = Camera.main.ScreenPointToRay(GetMousCoordinate());
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
        //if(hit2D.transform.gameObject.layer == LayerMask.NameToLayer("UI")) return default;
        if (hit2D.collider != null)
        {
            return hit2D.point;
        }

        return default;
    }
}
