using System;
using UnityEngine;

public class HostageInteractor : MonoBehaviour
{
    [SerializeField] private CreaturesData _data;
    [SerializeField] private LayerMask _playerLayer;
    private Transform _player;
    private bool _isMoving;
    private void Update()
    {
        Inputs();
        Move();
    }

    private void Move()
    {
        if (_isMoving)
        {
            _data._playerMovement.MoveOnTarget(_player.position);
            _data._playerMovement.LookAtTarget(_player.position);
        }
    }

    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.E) && CheckPlayers() && !_isMoving)
        {
            _isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && CheckPlayers() && _isMoving)
        {
            _player = transform;
            _isMoving = false;
        }
    }

    private bool CheckPlayers()
    {
        Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, 2, _playerLayer);
        if(players.Length > 0)  _player = players[0].transform;
        return players.Length > 0;
    }
}
