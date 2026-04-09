using System.Collections;
using Source.Creatures.Health;
using Source.Players.Movement;
using UnityEngine;

public class PlayerHealth : CreatureHealth
{
    [SerializeField] private PlayerUiDrawer _playerUiDrawer;
    [SerializeField] private UiDamageShower _uiDamageShower;
    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private bool _isRevived;
    protected override void Start()
    {
        base.Start();
    }

    public override void GetDamage(float damage, Vector3 enemyPos)
    {
        base.GetDamage(damage, enemyPos);
        _audioSource.PlayOneShot(_audioClip);
        StartCoroutine(LookAtTarget(enemyPos));
        _uiDamageShower.GetDamage();
    }
    IEnumerator LookAtTarget(Vector3 enemyPos)
    {
        yield return new WaitForSeconds(_timeToReaction);
        _creaturesData._playerMovement.LookAtTarget(enemyPos);
    }


    public override void Revive()
    {
        base.Revive();
        _creaturesData._playerMovement.GetComponent<PlayerMovement>().StopAgent(false);
        
        _isRevived = true;
    }
    

    protected override void Death()
    {
        base.Death();
        _playerAnimator.Death();
        _creaturesData._playerState.SetAlive(_isAlive);
        _gameplayStagesManager.PlayerKilled();
        if (gameObject.TryGetComponent<FerretPassive>(out var ferretPassive) && !_isRevived)
        {
            Revive();
            _isRevived = true;
        }
    }

    public override void AddHealth(float health)
    {
        base.AddHealth(health);
    }

    public bool GetIsRevived()
    {
        return _isRevived;
    }

    public PlayerUiDrawer GetPlayerUiDrawer()
    {
        return _playerUiDrawer;
    }
}
