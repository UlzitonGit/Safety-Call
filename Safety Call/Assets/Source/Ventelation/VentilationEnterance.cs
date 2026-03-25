using System;
using Source.Players.Controls;
using Source.Players.Movement;
using UnityEngine;

public class VentilationEnterance : MonoBehaviour, IHackable
{
    [SerializeField] private VentilationController _ventilationController;
    [SerializeField] private Transform _enterPosition;

    public void Hack()
    {
        if (!_ventilationController._isInVentilation)
        {
            _ventilationController.VentilationEnter(_enterPosition);
        }
    }
}
