using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private Vector3 lastMousePosition;
    private Vector3 dragOrigin;
    private bool isDragging = false;
    private float scroll;

    private InputAction _zoomCameraAction;
    private InputAction _moveCameraAction;

    private void OnEnable()
    {
        _zoomCameraAction = InputManager.Instance.GameInput.Base.ScaleCamera;
        _moveCameraAction = InputManager.Instance.GameInput.Base.MoveCamera;

        _moveCameraAction.started += StartHandleDrag;
        _moveCameraAction.canceled += StopHandleDrag;
    }

   

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
        HandleZoom(_zoomCameraAction.ReadValue<float>());
        HandleDrag();
        ClampCameraPosition();
    }

    private void OnDisable()
    {
        _moveCameraAction.started -= StartHandleDrag;
        _moveCameraAction.canceled -= StopHandleDrag;
    }

    private void StartHandleDrag(InputAction.CallbackContext ctx)
    {
        isDragging = true;
        dragOrigin = GetMouseWorldPosition();
        lastMousePosition = Input.mousePosition;
    }

    private void StopHandleDrag(InputAction.CallbackContext ctx)
    {
        isDragging = false;
    }

    private void HandleZoom(float scroll)
    {
        if (scroll != 0f)
        {
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
    
    void HandleDrag()
    {
        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 mouseDelta = currentMousePosition - lastMousePosition;
            
            Vector3 cameraMovement = new Vector3(-mouseDelta.x, -mouseDelta.y, 0) * (dragSpeed * Time.deltaTime / Time.timeScale);
            
            transform.Translate(cameraMovement);
            
            lastMousePosition = currentMousePosition;
        }
    }
    
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
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