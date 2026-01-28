using System.Collections;
using UnityEngine;

public abstract class AbilityBase : MonoBehaviour
{
    [SerializeField] private float _reloadTime;
    
    [HideInInspector] public bool CanBeUsed = true;

    [SerializeField] protected int _usageCount;
    public abstract void UseAbility();

    protected IEnumerator Reloading()
    {
        CanBeUsed = false;
        yield return new WaitForSeconds(_reloadTime);
        CanBeUsed = true;
    }
}
