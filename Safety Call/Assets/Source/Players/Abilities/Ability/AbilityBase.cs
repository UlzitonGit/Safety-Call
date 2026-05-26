using System.Collections;
using UnityEngine;

public abstract class AbilityBase : MonoBehaviour
{
    [SerializeField] protected float _reloadTime;
    
    [HideInInspector] public bool CanBeUsed = true;

    [SerializeField] protected int _usageCount;
    [SerializeField] protected GameObject _hint;
    public abstract void UseAbility();
    public abstract void ShowHint();
    
    public abstract void Cancel();

    protected IEnumerator Reloading()
    {
        CanBeUsed = false;
        yield return new WaitForSeconds(_reloadTime);
        CanBeUsed = true;
    }
}
