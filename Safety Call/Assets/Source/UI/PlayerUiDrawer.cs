using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUiDrawer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _namesMeshProUGUI;
    
    [SerializeField] private Image[] _hpBar;
    
    [SerializeField] private string _name;

    private void Start()
    {
        foreach (var name in _namesMeshProUGUI)
        {
            name.text = _name;
        }
    }

    public void UpdateUI(float health)
    {
        foreach (var hpBar in _hpBar)
        {
            hpBar.fillAmount = health / 100;
        }
    }
}
