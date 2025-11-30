using Source.Core;
using Source.Players.Controls;
using Source.Players.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSingleControlInput : MonoBehaviour
{
    [SerializeField] public PlayerMovement _playerMovement;
    [SerializeField] private PlayerChooser _playerChooser;
    private InputAction _missionMoveAction;
    private InputAction _hubMoveAction;
    private InputAction _stayOnMe;

    private void OnEnable()
    {
        _missionMoveAction = InputManager.Instance.GameInput.IndividualMove.Move;
        _hubMoveAction = InputManager.Instance.GameInput.Hub.Move;
        _stayOnMe = InputManager.Instance.GameInput.IndividualMove.StayOnMyPos;

        _stayOnMe.performed += StayOnMe;
    }

    void Update()
    {
        _playerMovement.MoveSingle(MoveVector());
        _playerMovement.LookAtTarget(GetClickCoordinates());
    }
    
    private void OnDisable()
    {
        _missionMoveAction = null;
        _hubMoveAction = null;
    }

    private Vector2 MoveVector()
    {
        if (InputManager.Instance.GameInput.IndividualMove.enabled)
        {
            return _missionMoveAction.ReadValue<Vector2>();
        }
        return _hubMoveAction.ReadValue<Vector2>();
    }
    
    private Vector3 GetMousCoordinate()
    {
        return new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), 1);
    }
   
    private void StayOnMe(InputAction.CallbackContext ctx)
    {
        foreach (var player in _playerChooser._creatureMovements)
        {
            player.MoveOnTarget(_playerMovement.transform.position);
            player.LookAtTarget(GetClickCoordinates());
        }
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
