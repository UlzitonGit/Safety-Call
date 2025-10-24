using UnityEngine;

public class GranadeThrower : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private GranadeAbstract[] _granades;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField]  private int _granadesCount = 3;
    private int _curentGranade = 0;

    public void Throw(Vector3 direction)
    {
        if(_granadesCount <= 0 && _playerData._playerState.IsAlive) return;
        GranadeAbstract _currentGranade = Instantiate(_granades[0], _spawnPoint.position, _spawnPoint.localRotation);
        _currentGranade.Throw();
        _granadesCount -= 1;
    }
}
