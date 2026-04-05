using Source.Players.Controls;
using Source.Players.Movement;
using UnityEngine;

public class VentilationController : MonoBehaviour
{
    [SerializeField] private GameObject _ventilation;
    [SerializeField] private GameObject _characterInVentilation;
    [SerializeField] private GameObject _character;
    [SerializeField] private PlayerData _generalHacker;
    [SerializeField] private PlayerData _hackerInVentilation;
    [SerializeField] private PlayerChooser _playerChooser;
    
    public bool _isInVentilation = false;
    private void Update()
    {
        if (_isInVentilation)
        {
            if (_playerChooser.GetPlayersChosen() != 1 || _playerChooser.GetChosenPlayers()[0] != _hackerInVentilation)
            {
                _ventilation.SetActive(false);
                _characterInVentilation.SetActive(false);
            }
            else if (_playerChooser.GetPlayersChosen() == 1 && _playerChooser.GetChosenPlayers()[0] == _hackerInVentilation)
            {
                _ventilation.SetActive(true);
                _characterInVentilation.SetActive(true);
            }
        }
    }

    public void VentilationExit(Transform exit)
    {
        _character.transform.position = exit.position;
        _isInVentilation = false;
        _ventilation.SetActive(false);
        _characterInVentilation.SetActive(false);
        _character.SetActive(true);

        _playerChooser._creatureMovements[0] =  _generalHacker._playerMovement.GetComponent<PlayerMovement>();
        _playerChooser.SetPlayerByData(_generalHacker._playerMovement.GetComponent<PlayerMovement>());
    }
    public void VentilationEnter(Transform enter)
    {
        _characterInVentilation.transform.position = enter.position;
        print(enter.position);
        print(_characterInVentilation.transform.position);
        _ventilation.SetActive(true);
        _characterInVentilation.SetActive(true);
        _character.SetActive(false);

        _playerChooser._creatureMovements[0] =  _hackerInVentilation._playerMovement.GetComponent<PlayerMovement>();
        _playerChooser.SetPlayerByData(_hackerInVentilation._playerMovement.GetComponent<PlayerMovement>());
        _isInVentilation = true;
    }
}
