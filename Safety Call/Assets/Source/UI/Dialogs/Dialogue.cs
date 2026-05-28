using System;
using Source.IntercativeObjects.ObjectsInHub;
using UnityEngine;

public class Dialogue : MonoBehaviour, IInteractable
{
    [SerializeField] private ShowInterface showInterface;
    [SerializeField] private DialogController dialogController;
    [SerializeField] private GameObject hint;
    [SerializeField] private int index;
    private bool canBeStarted = false;
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        hint.SetActive(true);
        showInterface.enabled = true;
        canBeStarted = true;
    }

    public void DoInteract()
    {
        if (canBeStarted)
        {
            showInterface.SetCanInteract(false);
            dialogController.StartDialog(index);
            hint.SetActive(false);
        }
    }
}
