using System;
using Source.Creatures.Health;
using UnityEngine;
using UnityEngine.UI;

public class HpBarUI : MonoBehaviour
{
   [SerializeField] private CreatureHealth _health;

   [SerializeField] private Image _hpBar;

   private void Update()
   {
      _hpBar.fillAmount = _health.CurrentHealth / 100;
   }
}
