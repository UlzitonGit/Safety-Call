using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]  private float zoomSpeed = 5f;
    [SerializeField] private float minZoom = 2f;
    [SerializeField] private float maxZoom = 10f;
    [SerializeField] private float dragSpeed = 2f;
    
    [SerializeField] private bool useBounds = true;
    [SerializeField] private Vector2 minBounds = new Vector2(-10f, -10f);
    [SerializeField] private Vector2 maxBounds = new Vector2(10f, 10f);
    
    private Camera cam;
    private Vector3 dragOrigin;
    private bool isDragging = false;
    
    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            cam = Camera.main;
        }
    }
    
    void Update()
    {
        HandleZoom();
        HandleDrag();
        ClampCameraPosition();
    }
    
    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        if (scroll != 0f)
        {
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
    
    void HandleDrag()
    {
        if (Input.GetMouseButtonDown(2))
        {
            isDragging = true;
            dragOrigin = GetMouseWorldPosition();
        }
        if (Input.GetMouseButtonUp(2))
        {
            isDragging = false;
        }
        if (isDragging)
        {
            Vector3 currentPos = GetMouseWorldPosition();
            Vector3 difference = dragOrigin - currentPos;
            
            transform.position += difference * dragSpeed;
        }
    }
    
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -transform.position.z;
        return cam.ScreenToWorldPoint(mousePos);
    }
    
    void ClampCameraPosition()
    {
        if (!useBounds) return;
        
        Vector3 clampedPosition = transform.position;
        
        float cameraHeight = cam.orthographicSize;
        float cameraWidth = cameraHeight * cam.aspect;
        
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, 
            minBounds.x + cameraWidth, 
            maxBounds.x - cameraWidth);
            
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, 
            minBounds.y + cameraHeight, 
            maxBounds.y - cameraHeight);
        
        transform.position = clampedPosition;
    }
    
    public void SetBounds(Vector2 newMinBounds, Vector2 newMaxBounds)
    {
        minBounds = newMinBounds;
        maxBounds = newMaxBounds;
    }
    
    void OnDrawGizmosSelected()
    {
        if (useBounds)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(new Vector3(
                (minBounds.x + maxBounds.x) * 0.5f,
                (minBounds.y + maxBounds.y) * 0.5f,
                0f),
                new Vector3(maxBounds.x - minBounds.x, maxBounds.y - minBounds.y, 0f));
        }
    }
}