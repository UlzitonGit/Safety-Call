using Source.Core;
using Source.Players.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilitiesController : MonoBehaviour
{
    [SerializeField] private PlayerChooser _playerChooser;
    [SerializeField] private PlayerUiDrawer _playerUiDrawer;
    private InputAction _useGranadeAction;
    private InputAction _abilityUserAction;
    private InputAction _abilityUserAction2;
    private InputAction _abilityUserAction3;
    private InputAction _cancelAction;
    AbilityUser _abilityUser;
    
    private bool EReady;
    private bool QReady;
    private bool DReady;
    private void OnEnable()
    {
        _useGranadeAction = InputManager.Instance.GameInput.Mission.UseGranade;
        _abilityUserAction = InputManager.Instance.GameInput.Mission.UseAbility;
        _abilityUserAction2 = InputManager.Instance.GameInput.Mission.UseAbility1;
        _abilityUserAction3 = InputManager.Instance.GameInput.Mission.UseAbility2;
        _cancelAction = InputManager.Instance.GameInput.Mission.CancelAbility;
        
        _useGranadeAction.performed += DoThrow;
        _abilityUserAction.performed += PerformAbilityE;
        _abilityUserAction2.performed += PerformAbilityQ;
        _abilityUserAction3.performed += PerformAbilityD;
        _cancelAction.performed += CancelAll;
    }

    private void OnDisable()
    {
        _useGranadeAction.performed -= DoThrow;
        _abilityUserAction.performed -= PerformAbilityE;
        _abilityUserAction2.performed -= PerformAbilityQ;
        _abilityUserAction3.performed -= PerformAbilityD;
        _cancelAction.performed -= CancelAll;
    }

    private void DoThrow(InputAction.CallbackContext ctx)
    {
        if (_playerChooser.GetPlayersChosen() == 1 )
        {
            PlayerData _currentPlayerData = _playerChooser.GetChosenPlayers()[0];
            _currentPlayerData._GranadeThrower.Throw(_currentPlayerData._playerMovement.GetClickedCoordinates());
        }
    }

    private void PerformAbilityE(InputAction.CallbackContext ctx)
    {
        if (_playerChooser.GetPlayersChosen() == 1 && _playerChooser.GetChosenPlayers()[0].gameObject.activeInHierarchy)
        {
            if (_abilityUser != null)
            {
                if (_abilityUser != _playerChooser.GetChosenPlayers()[0]._AbilityUser)
                {
                    QReady=false;
                    EReady=false;
                    DReady=false;
                    CloseAllHints();
                }
            }
            PlayerData _currentPlayerData = _playerChooser.GetChosenPlayers()[0];
            if( _currentPlayerData._AbilityUser._abilities.Count >= 1 && _currentPlayerData._playerState.IsAlive)
            {
                CloseAllHints();
                QReady = false;
                DReady = false;
                _currentPlayerData._AbilityUser._abilities[0].ShowHint(); 
                _playerUiDrawer.AbilityHintPanel(0, "E");
                _abilityUser = _currentPlayerData._AbilityUser;
            }
            else
            {
                EReady = false;
                return;
            }
            
            if (EReady)
            {
                _currentPlayerData._AbilityUser._abilities[0].UseAbility();
                _currentPlayerData._AbilityUser._abilities[0].Cancel();
                CloseAllHints();
                EReady = false;
                return;
            }

            EReady = true;

        }
    }
    private void PerformAbilityQ(InputAction.CallbackContext ctx)
    {
        if (_playerChooser.GetPlayersChosen() == 1 && _playerChooser.GetChosenPlayers()[0].gameObject.activeInHierarchy)
        {
            if (_abilityUser != null)
            {
                if (_abilityUser != _playerChooser.GetChosenPlayers()[0]._AbilityUser)
                {
                    QReady=false;
                    EReady=false;
                    DReady=false;
                    CloseAllHints();
                }
            }
    
            PlayerData _currentPlayerData = _playerChooser.GetChosenPlayers()[0];
            if( _currentPlayerData._AbilityUser._abilities.Count >= 2 && _currentPlayerData._playerState.IsAlive)
            {
                EReady = false;
                DReady = false;
                CloseAllHints();
                _playerUiDrawer.AbilityHintPanel(1, "Q");
                _currentPlayerData._AbilityUser._abilities[1].ShowHint();    
                _abilityUser = _currentPlayerData._AbilityUser;
            }
            else
            {
                QReady = false;
                return;
            }
            
            if (QReady)
            {
                _currentPlayerData._AbilityUser._abilities[1].UseAbility();
                _currentPlayerData._AbilityUser._abilities[1].Cancel();
                CloseAllHints();
                QReady = false;
                return;
            }

            QReady = true;
        }
    }
    private void PerformAbilityD(InputAction.CallbackContext ctx)
    {
        if (_playerChooser.GetPlayersChosen() == 1 && _playerChooser.GetChosenPlayers()[0].gameObject.activeInHierarchy)
        {
            if (_abilityUser != null)
            {
                if (_abilityUser != _playerChooser.GetChosenPlayers()[0]._AbilityUser)
                {
                    QReady=false;
                    EReady=false;
                    DReady=false;
                    CloseAllHints();
                }
            }
            PlayerData _currentPlayerData = _playerChooser.GetChosenPlayers()[0];
            if (_currentPlayerData._AbilityUser._abilities.Count >= 3 && _currentPlayerData._playerState.IsAlive)
            {
                QReady = false;
                EReady = false;
                CloseAllHints();
                _playerUiDrawer.AbilityHintPanel(2, "D");
                _currentPlayerData._AbilityUser._abilities[2].ShowHint();    
                _abilityUser = _currentPlayerData._AbilityUser;
            }
            

            else
            {
                DReady = false;
                return;
            }
            
            if (DReady)
            {
                _currentPlayerData._AbilityUser._abilities[2].UseAbility();
                _currentPlayerData._AbilityUser._abilities[2].Cancel();
                CloseAllHints();
                DReady = false;
                return;
            }

            DReady = true;
        }
    }

    private void CancelAll(InputAction.CallbackContext ctx)
    {
        QReady = false;
        DReady = false;
        EReady = false;
        CloseAllHints();
    }
    private void CloseAllHints()
    {
        if(_abilityUser == null) return;
        _playerUiDrawer.CloseAbilityPanel();
            _abilityUser._abilities[0].Cancel();
            _abilityUser._abilities[1].Cancel();
            _abilityUser._abilities[2].Cancel();
    }
}
