using System;
using System.Collections;
using UnityEngine;

public class EnemyVisibility : MonoBehaviour
{
   public bool IsVisible;
   
   [SerializeField] private GameObject _meshRenderer;
   [SerializeField] private SpriteRenderer _weaponGameObject;
   Coroutine _hideCoroutine;

   private EnemyStates _enemyStates;
   
   private float _timeToHide;

   private void Start()
   {
      _enemyStates = GetComponent<EnemyStates>();
      HideEnemy();
   }

   private void Update()
   {
      if (_timeToHide > 0 && _enemyStates.IsVisible)
      {
         _timeToHide -= Time.deltaTime;
      }
      else if (_timeToHide <= 0)
      {
         HideEnemy();
      }
   }

   public void ShowEnemy()
   {
      print("Show");
      IsVisible = true;
      _weaponGameObject.enabled = true;
      _meshRenderer.SetActive(true);
      _enemyStates.SetVisible(IsVisible);
      _timeToHide = 0.4f;
   }

   public void HideEnemy()
   {
      _meshRenderer.SetActive(false);
      _weaponGameObject.enabled = false;
      IsVisible = false;
      _enemyStates.SetVisible(IsVisible);
   }
   
}
