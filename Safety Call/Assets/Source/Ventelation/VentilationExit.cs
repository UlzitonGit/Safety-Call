using System;
using UnityEngine;

public class VentilationExit : MonoBehaviour
{
    [SerializeField] private VentilationController _ventilationController;
    [SerializeField] private Transform _exitPosition;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("VentilationPlayer") )
        {
            _ventilationController.VentilationExit(_exitPosition);
        }
    }
}
