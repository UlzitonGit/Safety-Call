using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerLoadout", order = 1)]
public class PlayerLoadoutSO : ScriptableObject
{
    public string CharaterName;

    public WeaponGeneral Weapon;

}