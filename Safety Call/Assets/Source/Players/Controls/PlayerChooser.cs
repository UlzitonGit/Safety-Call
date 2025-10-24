using System;
using System.Collections.Generic;
using Source.Creatures.Movement;
using Source.Players.Movement;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Players.Controls
{
    public class PlayerChooser : MonoBehaviour
    {
        [SerializeField] private PlayerMovement[] _creatureMovements;
    
        [SerializeField] private PlayerMoveInput _playerMoveInput;
    
        [SerializeField] private PlayerSpotlighter _playerSpotlighter;

        private int _playersChoosen;
        
        private List<PlayerData> _players;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SetChosenPlayer(AddPlayersToList(new []{0}));
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                SetChosenPlayer(AddPlayersToList(new []{1}));
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                SetChosenPlayer(AddPlayersToList(new []{2}));
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                SetChosenPlayer(AddPlayersToList(new []{3}));
            }

            if (Input.GetKey(KeyCode.C))
            {
                SetChosenPlayer(AddPlayersToList(new []{0,1}));
            }

            if (Input.GetKey(KeyCode.B))
            {
                SetChosenPlayer(AddPlayersToList(new []{2,3}));
            }

            if (Input.GetKey(KeyCode.H))
            {
                SetChosenPlayer(AddPlayersToList(new []{0, 1, 2,3}));
            }
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
