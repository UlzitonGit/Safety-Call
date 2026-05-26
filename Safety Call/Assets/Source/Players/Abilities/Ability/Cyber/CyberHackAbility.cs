using UnityEngine;

public class CyberHackAbility : AbilityBase
{ 
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _hackRange;
    public override void UseAbility()
    {
        Collider2D toHack = Physics2D.OverlapCircle(transform.position, _hackRange, _layerMask);
        print("Hack");
        if(toHack != null)
            toHack.GetComponent<IHackable>().Hack();
    }
    public override void ShowHint()
    {
        _hint.SetActive(true);
    }

    public override void Cancel()
    {
        _hint.SetActive(false);
    }
}
