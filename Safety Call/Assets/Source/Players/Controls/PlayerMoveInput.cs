using UnityEngine;

public class PlayerMoveInput : MonoBehaviour
{
    private CreatureMovement _playerMovement;
    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            MakePlayerMove(GetClickCoordinates());
        }
    }

    public void SetPlayerMovement(CreatureMovement playerMovement)
    {
        _playerMovement = playerMovement;
    }

    private Vector3 GetClickCoordinates()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
        if (hit2D.collider != null)
        {
            return hit2D.point;
        }

        return default;
    }
    private void MakePlayerMove(Vector3 position)
    {
        if(_playerMovement == null) return;
        _playerMovement.MoveOnTarget(position);
    }
}
