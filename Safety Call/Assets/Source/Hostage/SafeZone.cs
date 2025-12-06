using System;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
   [SerializeField] private GameplayStagesManager _gameplayStagesManager;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Hostage"))
      {
         other.gameObject.SetActive(false);
         _gameplayStagesManager.HostageRescued();
      }
   }
}
