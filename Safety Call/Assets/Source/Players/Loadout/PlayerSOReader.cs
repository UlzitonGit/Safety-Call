using System;
using UnityEngine;

public class PlayerSOReader : MonoBehaviour
{
  
    [SerializeField] PlayerLoadoutSO playerLoadout;
    
    [SerializeField] private WeaponController _weaponController;

    [SerializeField] private Transform _weaponPoint;
    
    private bool spawned = false;

    private void Start()
    {
        if(playerLoadout != null && !spawned)
            _weaponController._weaponGeneral = Instantiate(playerLoadout.Weapon.gameObject, _weaponPoint).GetComponent<WeaponGeneral>();
    }

    public void SetWeapon(PlayerLoadoutSO player)
    {
        playerLoadout = player;
        _weaponController._weaponGeneral = Instantiate(playerLoadout.Weapon.gameObject, _weaponPoint).GetComponent<WeaponGeneral>();
        spawned = true;
    }
}
