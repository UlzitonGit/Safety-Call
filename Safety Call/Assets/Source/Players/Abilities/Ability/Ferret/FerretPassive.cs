using UnityEngine;

public class FerretPassive : MonoBehaviour
{
    [SerializeField] private HealingPistol _healingP;

    public void AddHealingPistolAmmo(int ammo)
    {
        _healingP.AddUsages(ammo);
    }
}
