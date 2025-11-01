using Source.Players.Movement;
using UnityEngine;

public class PlayerSingleControlInput : MonoBehaviour
{
    [SerializeField] public PlayerMovement _playerMovement;
    
    void Update()
    {
        _playerMovement.MoveSingle(GetControls());
        _playerMovement.LookAtTarget(GetClickCoordinates());
    }

    private Vector2 GetControls()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    public Vector3 GetClickCoordinates()
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
}
