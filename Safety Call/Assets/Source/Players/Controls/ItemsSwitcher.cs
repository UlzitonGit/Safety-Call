using UnityEngine;

public class ItemsSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;
    
    private int _currentIndex = 0;
    
    public void SwitchToTargetedObject(GameObject objectToSwitch)
    {
        _objects[_currentIndex].gameObject.SetActive(false);
        int index = 0;
        foreach (var _object in _objects)
        {
            if (_object == objectToSwitch)
            {
                _currentIndex = index;
                _object.SetActive(true);
            }

            index++;
        }
    }

    public void SwitchToIndexObject(int index)
    {
        _objects[_currentIndex].gameObject.SetActive(false);
        _currentIndex = index;
        if(_currentIndex > _objects.Length-1) _currentIndex = 0;
        else if(_currentIndex < 0) _currentIndex = _objects.Length-1;
        _objects[_currentIndex].gameObject.SetActive(true);
    }
}
