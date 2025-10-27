using Source.Players.Movement;
using UnityEngine;

public class PlayerData : CreaturesData
{
    [field:SerializeField] public PlayerVisibility _playerVisibility { get; private set; }
    [field:SerializeField] public GranadeThrower _GranadeThrower { get; private set; }
    
    [field:SerializeField] public PlayerGunfightBehaviour _PlayerGunfightBehaviour{ get; private set; }
    
    [field:SerializeField] public PlayerWeaponController _PlayerWeaponController { get; private set; }
}
