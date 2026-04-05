using System;
using System.Collections.Generic;
using Source.Players.Controls;
using Source.Players.Movement;
using UnityEngine;

public class HubAutoPick : MonoBehaviour
{
    [SerializeField] List<PlayerMovement> playerMovements;
    [SerializeField] PlayerTacticalControlInput playerTacticalControlInput;

    private void Start()
    {
        playerTacticalControlInput.SetPlayerMovement(playerMovements);
    }
}
