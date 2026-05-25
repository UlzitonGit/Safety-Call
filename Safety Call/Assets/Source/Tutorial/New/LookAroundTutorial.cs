using System;
using UnityEngine;

public class LookAroundTutorial : MonoBehaviour
{
    [SerializeField] private TutorialController _tutorialController;
    [SerializeField] private GameObject uiHint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera"))
        {
            gameObject.SetActive(false);
            uiHint.SetActive(false);
            _tutorialController.NextStage();
        }
    }
}
