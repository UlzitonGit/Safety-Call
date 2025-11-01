using UnityEngine;

public class BeastBalisticShield : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private ItemsSwitcher _switcher;
    [SerializeField] private GameObject _shield;
    
    private bool _shieldActive;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _playerData._PlayerGunfightBehaviour._isControlling && !_shieldActive)
        {
            _switcher.SwitchToTargetedObject(_shield);
            _shieldActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && _playerData._PlayerGunfightBehaviour._isControlling && _shieldActive)
        {
            _switcher.SwitchToIndexObject(0);
            print("SwitchToIndexObject");
            _shieldActive = false;
        }
    }
}
