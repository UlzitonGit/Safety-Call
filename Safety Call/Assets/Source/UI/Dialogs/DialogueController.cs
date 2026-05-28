using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInvoker : MonoBehaviour
{
    [SerializeField] private Dialogs[] dialogs;
    private int currentLevel;
    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("LevelsCompleted");
        foreach (Dialogs dialog in dialogs)
        {
            if(currentLevel == dialog.index)
            {
                dialog.Dialog.SetActive(true);
            }
        }
    }
}
[Serializable]
public class Dialogs
{
    public GameObject Dialog;
    public int index;
}