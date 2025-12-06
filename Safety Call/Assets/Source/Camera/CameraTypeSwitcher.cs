using UnityEngine;

public class CameraTypeSwitcher : MonoBehaviour
{  
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private CameraIndividualController _cameraIndividual;

    public void SwitchCameraToTacticalControl()
    {
        _cameraController.enabled = true;
        _cameraIndividual.enabled = false;
    }

    public void SwitchCameraToSinglePlayerControl(Transform target)
    {
        _cameraIndividual.enabled = true;
        _cameraIndividual.SetTarget(target);
        _cameraController.enabled = false;
    }
}
