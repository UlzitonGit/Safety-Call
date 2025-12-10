using System;
using UnityEngine;

public class HostageInteractor : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
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
            transform.position = Vector3.Lerp(transform.position, _player.position, _speed * Time.deltaTime);
        }
    }

    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.E) && CheckPlayers() && !_isMoving)
        {
            _animator.SetBool("isMoving", true);
            _isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && CheckPlayers() && _isMoving)
        {
            _player = transform;
            _animator.SetBool("isMoving", false);
            _isMoving = false;
        }
    }

    private bool CheckPlayers()
    {
        Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, 2, _playerLayer);
        foreach (var player in players)
        {
            if (player.GetComponent<PlayerData>()._playerState.IsAlive)
            {
                _player = player.transform;
            }
        }
        return players.Length > 0;
    }
}
