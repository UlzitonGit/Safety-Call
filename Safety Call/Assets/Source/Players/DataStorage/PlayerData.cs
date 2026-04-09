using System;
using Source.Players.Movement;
using UnityEngine;

public class PlayerData : CreaturesData
{
    [field:SerializeField] public PlayerVisibility _playerVisibility { get; private set; }
    [field:SerializeField] public GranadeThrower _GranadeThrower { get; private set; }
    
    [field:SerializeField] public PlayerGunfightBehaviour _PlayerGunfightBehaviour{ get; private set; }
    
    [field:SerializeField] public PlayerWeaponController _PlayerWeaponController { get; private set; }
    
    [field:SerializeField] public FieldOfView _FieldOfView { get; private set; }
    
    [field:SerializeField] public AbilityUser _AbilityUser { get; private set; }
    
    public ObservableValue<int> MaxAmmo { get; set; }
    public ObservableValue<int> CurrentAmmo { get; set; }
    public ObservableValue<string> Status { get; } = new ObservableValue<string>("Idle");


    private void Start()
    {
        MaxAmmo = new ObservableValue<int>(_PlayerWeaponController._weaponGeneral.GetMaxAmmo());
        CurrentAmmo = new ObservableValue<int>(_PlayerWeaponController._weaponGeneral.GetCurrentAmmo());
        
    }
}
