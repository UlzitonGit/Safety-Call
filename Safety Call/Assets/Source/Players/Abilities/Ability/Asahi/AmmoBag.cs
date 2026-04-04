using System.Collections;
using UnityEngine;

public class AmmoBag : AbilityBase
{
    [SerializeField] private GameObject _ammoBox;
    private GameObject __ammoBoxInstance;
    public override void UseAbility()
    {
        if(_usageCount == 0 || !CanBeUsed) return;
        _usageCount -= 1;
        CanBeUsed = false;
        __ammoBoxInstance = Instantiate(_ammoBox, transform.position, Quaternion.identity);
        StartCoroutine(BufferCountDown());
    }

    IEnumerator BufferCountDown()
    {
        yield return new WaitForSeconds(_reloadTime / 2);
        Destroy(__ammoBoxInstance.gameObject);
        yield return new WaitForSeconds(_reloadTime / 2);
        CanBeUsed = true;
    }
}