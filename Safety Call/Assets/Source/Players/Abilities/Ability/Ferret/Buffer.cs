using System.Collections;
using UnityEngine;

public class Buffer : AbilityBase
{
    [SerializeField] private GameObject _buffer;
    private GameObject _bufferInstance;
    public override void UseAbility()
    {
        if(_usageCount == 0 || !CanBeUsed) return;
        _usageCount -= 1;
        _bufferInstance = Instantiate(_buffer, transform.position, Quaternion.identity);
        StartCoroutine(BufferCountDown());
    }

    IEnumerator BufferCountDown()
    {
        yield return new WaitForSeconds(_reloadTime / 2);
        Destroy(_bufferInstance.gameObject);
    }
}
