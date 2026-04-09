using System;
using Source.Players.Controls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUiDrawer : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private GameObject _noInfoPanel;
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI maxAmmoText;
    [SerializeField] private TextMeshProUGUI currentAmmoText;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Button[] abilityButtons;
    [SerializeField] private Image[] abilityCooldownImages;
    private PlayerData _viewModel;
    private GameObject _currentPanel;

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
        _viewModel.MaxAmmo.OnValueChanged += UpdateMaxAmmoUI;
        _viewModel.CurrentAmmo.OnValueChanged += UpdateCurrentAmmoUI;
        _viewModel.Status.OnValueChanged += UpdateStatusUI;
        
        UpdateHealthUI(_viewModel._playerHealth.Health.Value);
        UpdateMaxAmmoUI(_viewModel.MaxAmmo.Value);
        UpdateCurrentAmmoUI(_viewModel.CurrentAmmo.Value);
        UpdateStatusUI(_viewModel.Status.Value);
    }
    
    private void OnDestroy()
    {
        if (_viewModel == null) return;
        
        _viewModel._playerHealth.Health.OnValueChanged -= UpdateHealthUI;
        _viewModel.MaxAmmo.OnValueChanged -= UpdateMaxAmmoUI;
        _viewModel.CurrentAmmo.OnValueChanged -= UpdateCurrentAmmoUI;
        _viewModel.Status.OnValueChanged -= UpdateStatusUI;
    }
    
    private void SetActivePanel(bool showPlayerPanel)
    {
        Debug.Log(showPlayerPanel ? "Show player UI" : "Show empty panel");
    }
    
    private void UpdateHealthUI(float health) => healthBar.fillAmount = health / 100f;
    private void UpdateMaxAmmoUI(int ammo) => maxAmmoText.text = ammo.ToString();
    private void UpdateCurrentAmmoUI(int ammo) => currentAmmoText.text = $"{ammo} /";
    private void UpdateStatusUI(string status) => statusText.text = status;
}
