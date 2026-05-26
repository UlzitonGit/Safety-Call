using Source.Creatures.Health;
using UnityEngine;

public class Revive : AbilityBase
{
    [SerializeField] private LayerMask _targetLayers;
    public override void UseAbility()
    {
        if(_usageCount == 0 || !CanBeUsed) return;
        
        Collider2D[] toRevive = Physics2D.OverlapCircleAll(transform.position, 2, _targetLayers);
        foreach (Collider2D col in toRevive)
        {
            col.gameObject.TryGetComponent<CreatureHealth>(out var health);
            if (!health.GetIsAlive())
            {
                _usageCount -= 1;
                health.Revive();
                break;
            }
        }
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
