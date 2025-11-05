using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMedic : ASpecialAbility
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private PlayerData _playerData;
    
    private int _reviveCount = 3;
    protected override void DoAbility(InputAction.CallbackContext ctx)
    {
        if (_playerData._PlayerGunfightBehaviour._isControlling)
        {
            CheckPlayersToRevive();
        }
    }
    private void CheckPlayersToRevive()
    {
        Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, 2, _layerMask);
        print("tryFind");
        foreach (Collider2D player in players)
        {
            print(player.gameObject.name);
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (_reviveCount > 0 && !playerHealth.GetIsAlive() && !playerHealth.GetIsRevived())
            {
                playerHealth.Revive();
                _reviveCount -= 1;
                print("REVIVE");
            }
        }
    }
}
