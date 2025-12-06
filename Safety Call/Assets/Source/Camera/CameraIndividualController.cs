using System;
using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraIndividualController : MonoBehaviour
{
    [Header("Target Settings")]
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);
    
    [Header("Follow Settings")]
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private bool followX = true;
    [SerializeField] private bool followY = true;
    [SerializeField]  private float zoomSpeed = 5f;
    
    [SerializeField] private float minZoom = 2f;
    [SerializeField] private float maxZoom = 10f;
    
    private InputAction _zoomCameraAction;
    
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _zoomCameraAction = InputManager.Instance.GameInput.Base.ScaleCamera;
    }
    

    void LateUpdate()
    {
        if (target == null) return;
        
        Vector3 desiredPosition = target.position + offset;
        
        if (!followX) desiredPosition.x = transform.position.x;
        if (!followY) desiredPosition.y = transform.position.y;
        
       
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        HandleZoom(_zoomCameraAction.ReadValue<float>());
    }
    private void HandleZoom(float scroll)
    {
        if (scroll != 0f)
        {
            _camera.orthographicSize -= scroll * zoomSpeed;
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, minZoom, maxZoom);
        }
    }
    
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
