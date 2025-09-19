using Source.Creatures.Health;
using UnityEngine;

public class AslautRifle : WeaponGeneral
{
    [SerializeField] private string _tag;
    
    

    protected override void Shoot()
    {
        base.Shoot();
    }

    protected override void DealDamage(RaycastHit2D hit)
    {
        if (!hit.collider.CompareTag(_tag)) return;
        print(hit.collider.name);
        hit.transform.GetComponent<CreatureHealth>().GetDamage(_damage, transform.position);
    }
}
