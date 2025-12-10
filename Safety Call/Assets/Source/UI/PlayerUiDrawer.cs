using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUiDrawer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _namesMeshProUGUI;
    
    [SerializeField] private Image[] _hpBar;
    
    [SerializeField] private string _name;
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
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

    public void PlayPickAnim(bool state)
    {
        _animator.SetBool("Picked", state);
    }
}
