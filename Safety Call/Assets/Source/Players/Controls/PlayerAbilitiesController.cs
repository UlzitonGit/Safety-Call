using System;
using Source.Players.Controls;
using UnityEngine;

public class PlayerAbilitiesController : MonoBehaviour
{
    [SerializeField] private PlayerChooser _playerChooser;

    private void Update()
    {
        if (_playerChooser.GetPlayersChoosen() == 1 && Input.GetKeyDown(KeyCode.G))
        {
            PlayerData _currentPlayerData = _playerChooser.GetChosenPlayer()[0];
            _currentPlayerData._GranadeThrower.Throw(_currentPlayerData._playerMovement.GetClickedCoordinates());
        }
    }
}
