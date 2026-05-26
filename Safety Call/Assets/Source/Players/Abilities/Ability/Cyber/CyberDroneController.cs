using System.Collections;
using System.Collections.Generic;
using Source.Players.Controls;
using UnityEngine;

public class CyberDroneController : AbilityBase
{
    [SerializeField] private PlayerTacticalControlInput _playerTacticalControlInput;
    [SerializeField] private GameObject drone;
    private Drone _droneInstance;

    public override void UseAbility()
    {
        if(_usageCount == 0 || !CanBeUsed) return;
        _usageCount -= 1;
        CanBeUsed = false;
        _droneInstance = Instantiate(drone, transform.position, Quaternion.identity).GetComponent<Drone>();
        _droneInstance.SetDestination(_playerTacticalControlInput.GetClickCoordinates());
        StartCoroutine(DroneCountDown());
    }

    IEnumerator DroneCountDown()
    {
        yield return new WaitForSeconds(_reloadTime / 2);
        Destroy(_droneInstance.gameObject);
        yield return new WaitForSeconds(_reloadTime / 2);
        CanBeUsed = true;
    }
    public override void ShowHint()
    {
        _hint.SetActive(true);
    }

    public override void Cancel()
    {
        _hint.SetActive(false);
    }
}
