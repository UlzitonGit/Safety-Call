using Source.Creatures.Health;
using UnityEngine;

public class AslautRifle : WeaponGeneral
{
    [SerializeField] private string _tag;


    public override void Shoot(Vector3 target)
    {
        base.Shoot(target);
    }

    protected override void DealDamage(RaycastHit2D hit)
    {
        if (!hit.collider.CompareTag(_tag)) return;
        print(hit.collider.name);
        hit.transform.GetComponent<CreaturesData>()._playerHealth.GetDamage(_damage, transform.position);
    }
}
