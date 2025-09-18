using System;
using Source.Creatures.Movement;
using Source.Players.Movement;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Players.Controls
{
    public class PlayerChooser : MonoBehaviour
    {
        [SerializeField] private Button[] _playerButtons;
    
        [SerializeField] private PlayerMovement[] _creatureMovements;
    
        [SerializeField] private PlayerMoveInput _playerMoveInput;
    
        [SerializeField] private PlayerSpotlighter _playerSpotlighter;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SetChosenPlayer(0);
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                SetChosenPlayer(1);
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                SetChosenPlayer(2);
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                SetChosenPlayer(3);
            }
        }

        public void SetChosenPlayer(int playerIndex)
        {
            if (_creatureMovements[playerIndex] != null)
            {
                _playerMoveInput.SetPlayerMovement(_creatureMovements[playerIndex]);
                _playerSpotlighter.SetChosenPlayer(playerIndex);
            }
        }
    }
}
