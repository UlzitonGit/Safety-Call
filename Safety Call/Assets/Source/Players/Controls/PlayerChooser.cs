using System.Collections.Generic;
using Source.Core;
using Source.Players.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Players.Controls
{
    public class PlayerChooser : MonoBehaviour
    {
        [SerializeField] private PlayerMovement[] _creatureMovements;
    
        [SerializeField] private PlayerTacticalControlInput _playerMoveInput;
    
        [SerializeField] private PlayerSpotlighter _playerSpotlighter;

        private int _playersChoosen;
        
        private List<PlayerData> _players;

        private InputAction _selectUnit1Action;
        private InputAction _selectUnit2Action;
        private InputAction _selectUnit3Action;
        private InputAction _selectUnit4Action;
        private InputAction _selectUnits12Action;
        private InputAction _selectUnits34Action;
        private InputAction _selectAllUnitsAction;

        private void OnEnable()
        {
            _selectUnit1Action = InputManager.Instance.GameInput.TacticalMove.SelectUnit1;
            _selectUnit2Action = InputManager.Instance.GameInput.TacticalMove.SelectUnit2;
            _selectUnit3Action = InputManager.Instance.GameInput.TacticalMove.SelectUnit3;
            _selectUnit4Action = InputManager.Instance.GameInput.TacticalMove.SelectUnit4;
            _selectUnits12Action = InputManager.Instance.GameInput.TacticalMove.SelectUnits12;
            _selectUnits34Action = InputManager.Instance.GameInput.TacticalMove.SelectUnits34;
            _selectAllUnitsAction = InputManager.Instance.GameInput.TacticalMove.SelectAllUnits;

            _selectUnit1Action.performed += SetFirstPlayer;
            _selectUnit2Action.performed += SetSecondPlayer;
            _selectUnit3Action.performed += SetThirdPlayer;
            _selectUnit4Action.performed += SetFourthPlayer;
            _selectUnits12Action.performed += SetFirstAndSecondPlayers;
            _selectUnits34Action.performed += SetThirdAndFourthPlayers;
            _selectAllUnitsAction.performed += SetAllPlayers;
        }

        private void OnDisable()
        {
            _selectUnit1Action.performed -= SetFirstPlayer;
            _selectUnit2Action.performed -= SetSecondPlayer;
            _selectUnit3Action.performed -= SetThirdPlayer;
            _selectUnit4Action.performed -= SetFourthPlayer;
            _selectUnits12Action.performed -= SetFirstAndSecondPlayers;
            _selectUnits34Action.performed -= SetThirdAndFourthPlayers;
            _selectAllUnitsAction.performed -= SetAllPlayers;
        }

        private void SetFirstPlayer(InputAction.CallbackContext ctx)
        {
            SetChosenPlayer(AddPlayersToList(new[] { 0 }));
        }

        private void SetSecondPlayer(InputAction.CallbackContext ctx)
        {
            SetChosenPlayer(AddPlayersToList(new[] { 1 }));
        }

        private void SetThirdPlayer(InputAction.CallbackContext ctx)
        {
            SetChosenPlayer(AddPlayersToList(new[] { 2 }));
        }

        private void SetFourthPlayer(InputAction.CallbackContext ctx)
        {
            SetChosenPlayer(AddPlayersToList(new[] { 3 }));
        }

        private void SetFirstAndSecondPlayers(InputAction.CallbackContext ctx)
        {
            SetChosenPlayer(AddPlayersToList(new[] { 0, 1 }));
        }

        private void SetThirdAndFourthPlayers(InputAction.CallbackContext ctx)
        {
            SetChosenPlayer(AddPlayersToList(new[] { 2, 3 }));
        }

        private void SetAllPlayers(InputAction.CallbackContext ctx)
        {
            SetChosenPlayer(AddPlayersToList(new[] { 0, 1, 2, 3 }));
        }

        public void SetChosenPlayer(List<int> playerIndexes)
        {
             List<PlayerMovement> playersToControl = new List<PlayerMovement>();
             _players = new List<PlayerData>();
             foreach (var index in playerIndexes)
             {
                 playersToControl.Add(_creatureMovements[index]);
                 _players.Add(_creatureMovements[index].GetComponent<PlayerData>());
                 print(_creatureMovements[index].gameObject.name);
             }
             _playerMoveInput.SetPlayerMovement(playersToControl);
             _playerSpotlighter.SetChosenPlayer(playerIndexes);
        }

        private List<int> AddPlayersToList(int[] indexes)
        {
            List<int> indexesToReturn = new List<int>();
            foreach (var index in indexes)
            {
                if (_creatureMovements[index] != null)
                {
                    print(_creatureMovements[index].gameObject.name);
                    indexesToReturn.Add(index);
                }
            }
            _playersChoosen = indexesToReturn.Count;
            return indexesToReturn;
        }

        public List<PlayerData> GetChosenPlayer()
        {
            return _players;
        }

        public int GetPlayersChoosen()
        {
            return _playersChoosen;
        }
    }
}
