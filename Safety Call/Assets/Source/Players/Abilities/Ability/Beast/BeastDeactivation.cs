using UnityEngine;

public class BeastDeactivation : AbilityBase
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _deactivationRange;
    public override void UseAbility()
    {
        Collider2D claymore = Physics2D.OverlapCircle(transform.position, _deactivationRange, _layerMask);
        if(claymore != null)
            claymore.GetComponentInChildren<Claymore>().Deactivate();
    }
}
