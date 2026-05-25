using System;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
   [SerializeField] private GameplayStagesManager _gameplayStagesManager;
   [SerializeField] private bool _isTutorial;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Hostage"))
      {
         other.gameObject.SetActive(false);
         _gameplayStagesManager.HostageRescued();
         if (_isTutorial)
         {
            FindAnyObjectByType<TutorialController>().HostageRescued();
         }
      }
   }
}
