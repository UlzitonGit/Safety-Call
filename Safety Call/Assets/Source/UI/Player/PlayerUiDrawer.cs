using System;
using Source.Players.Controls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUiDrawer : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private GameObject _noInfoPanel;
    [SerializeField] private Image _healthBar;
    [SerializeField] private TextMeshProUGUI _maxAmmoText;
    [SerializeField] private TextMeshProUGUI _currentAmmoText;
    [SerializeField] private TextMeshProUGUI _statusText;
    [SerializeField] private Image _missionStatusBar;
    [SerializeField] private Image[] _abilityIcons;
    [SerializeField] private TextMeshProUGUI _hostages;
    [SerializeField] private TextMeshProUGUI _enemiesKilled;
    [SerializeField] private TextMeshProUGUI _percentsText;
    [SerializeField] private GameObject _abilityPanel;
    [SerializeField] private TextMeshProUGUI _abilityTextMain;
    [SerializeField] private TextMeshProUGUI _abilityUseText;
    private PlayerData _viewModel;
    private GameplayStagesManager _gamePlayStatesUI;
    private GameObject _currentPanel;

    private void Start()
    {
        ShowUndefPanel();
        
    }

    public void InitializeState(GameplayStagesManager gamePlayStatesUI)
    {
        _gamePlayStatesUI = gamePlayStatesUI;
        _gamePlayStatesUI.Enemies.OnValueChanged += UpdateEnemies;
        _gamePlayStatesUI.Hostages.OnValueChanged += UpdateHostages;
        _gamePlayStatesUI.Percents.OnValueChanged += UpdatePercents;
        
        UpdateEnemies(0);
        UpdateHostages(0);
    }
    public void ShowUndefPanel()
    {
        _infoPanel.SetActive(false);
        _noInfoPanel.SetActive(true);
    }
    public void Bind(PlayerData viewModel)
    {
        
        _viewModel = viewModel;
        
        if (_viewModel == null)
        {
            return;
        }
        _infoPanel.SetActive(true);
        _noInfoPanel.SetActive(false);
        
        _viewModel._playerHealth.Health.OnValueChanged += UpdateHealthUI;
        _viewModel._PlayerWeaponController._weaponGeneral.MaxAmmo.OnValueChanged += UpdateMaxAmmoUI;
        _viewModel._PlayerWeaponController._weaponGeneral.CurrentAmmo.OnValueChanged += UpdateCurrentAmmoUI;
        _viewModel._playerHealth.Status.OnValueChanged += UpdateStatusUI;
        
        
        UpdateHealthUI(_viewModel._playerHealth.Health.Value);
        UpdateMaxAmmoUI(viewModel._PlayerWeaponController._weaponGeneral.MaxAmmo.Value);
        UpdateCurrentAmmoUI(viewModel._PlayerWeaponController._weaponGeneral.CurrentAmmo.Value);
        UpdateStatusUI(_viewModel._playerHealth.Status.Value);
        UpdateIcons();
    }
    
    private void OnDestroy()
    {
        if (_viewModel == null) return;
        
        _viewModel._playerHealth.Health.OnValueChanged -= UpdateHealthUI;
        _viewModel._PlayerWeaponController._weaponGeneral.MaxAmmo.OnValueChanged -= UpdateMaxAmmoUI;
        _viewModel._PlayerWeaponController._weaponGeneral.CurrentAmmo.OnValueChanged -= UpdateCurrentAmmoUI;
        _viewModel._playerHealth.Status.OnValueChanged -= UpdateStatusUI;
    }
    
    private void SetActivePanel(bool showPlayerPanel)
    {
        Debug.Log(showPlayerPanel ? "Show player UI" : "Show empty panel");
    }
    
    private void UpdateHealthUI(float health) => _healthBar.fillAmount = health / 100f;
    private void UpdateMaxAmmoUI(int ammo) => _maxAmmoText.text = ammo.ToString();
    private void UpdateCurrentAmmoUI(int ammo) => _currentAmmoText.text = $"{ammo} /";
    private void UpdateStatusUI(string status) => _statusText.text = status;
    private void UpdateHostages(int hostages) => _hostages.text = $"{hostages} / {_gamePlayStatesUI.AllHostages}";
    private void UpdateEnemies(int enemies) => _enemiesKilled.text = $"{enemies} / {_gamePlayStatesUI.AllEnemies}";
    private void UpdatePercents(float percents)
    { 
        _missionStatusBar.fillAmount = percents / 100;
        _percentsText.text = $"{percents} %";
    }
    public void ShowAbilityPanel(int index, GameObject _abilityPanel, TextMeshProUGUI _abilityText)
    {
        _abilityPanel.SetActive(true);
        _abilityText.text = _viewModel._AbilitySO.GetDescription(index);
    }

    public void AbilityHintPanel(int index, string use)
    {
        _abilityPanel.SetActive(true);
        _abilityTextMain.text = $"{_viewModel._AbilitySO.GetDescription(index)}";
        _abilityUseText.text = "PRESS " + use + " TO CONFIRM";
    }

    public void CloseAbilityPanel()
    {
        _abilityPanel.SetActive(false);
    }
    private void UpdateIcons()
    {
        for (int i = 0; i < _abilityIcons.Length; i++)
        {
            _abilityIcons[i].sprite = _viewModel._AbilitySO.GetIcon(i);
        }
    }
}
