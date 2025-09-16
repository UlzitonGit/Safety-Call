using UnityEngine;
using UnityEngine.UI;

public class PlayerChooser : MonoBehaviour
{
    [SerializeField] private Button[] _playerButtons;
    
    [SerializeField] private CreatureMovement[] _creatureMovements;
    
    [SerializeField] private PlayerMoveInput _playerMoveInput;
    
    [SerializeField] private PlayerSpotlighter _playerSpotlighter;

    public void SetChosenPlayer(int playerIndex)
    {
        _playerMoveInput.SetPlayerMovement(_creatureMovements[playerIndex]);
        _playerSpotlighter.SetChosenPlayer(playerIndex);
    }
}
