using System;
using System.Collections;
using UnityEngine;

public class EnemyVisibility : MonoBehaviour
{
   [SerializeField] private GameObject _meshRenderer;
   Coroutine _hideCoroutine;
   private float _timeToHide;

   private void Start()
   {
      HideEnemy();
   }

   private void Update()
   {
      if (_timeToHide > 0)
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
      _meshRenderer.SetActive(true);
      _timeToHide = 1.0f;
   }

   public void HideEnemy()
   {
      _meshRenderer.SetActive(false);
   }
   
}
