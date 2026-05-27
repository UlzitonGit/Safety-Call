using System;
using System.Collections;
using UnityEngine;

public class EnemyVisibility : MonoBehaviour, IPlayerSpotable
{
   public bool IsVisible;
   
   [SerializeField] private GameObject _meshRenderer;
   [SerializeField] private GameObject _weapon;
   
   public SpriteRenderer[] _weaponGameObject;
   Coroutine _hideCoroutine;

   private EnemyStates _enemyStates;
   
   private float _timeToHide;
   

   private void Start()
   {
      _enemyStates = GetComponent<EnemyStates>();
      _weaponGameObject = _weapon.GetComponentsInChildren<SpriteRenderer>();
      
      HideEnemy();
   }

   private void Update()
   {
      if (_timeToHide > 0 && _enemyStates.IsVisible)
      {
         _timeToHide -= Time.deltaTime;
      }
      else if (_timeToHide <= 0 && _enemyStates.IsAlive)
      {
         HideEnemy();
      }
   }

   public void ShowEnemy()
   {
      print("Show");
      IsVisible = true;
      _meshRenderer.SetActive(true);
      HideWeapon(true);
      _enemyStates.SetVisible(IsVisible);
      _timeToHide = 0.4f;
   }

   public void HideEnemy()
   {
      _meshRenderer.SetActive(false);
      HideWeapon(false);
      IsVisible = false;
      _enemyStates.SetVisible(IsVisible);
   }

   private void HideWeapon(bool hide)
   {
      foreach (var sprite in _weaponGameObject)
      {
         sprite.enabled = hide;
      }
   }
   
}
