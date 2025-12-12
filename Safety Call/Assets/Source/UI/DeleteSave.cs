using System.Collections.Generic;
using UnityEngine;

public class DeleteSave : MonoBehaviour
{
    [SerializeField] private List<DialoguesDataSO> dialoguesDataSOs;

    public void DeleteDialogueSave()
    {
        PlayerPrefs.DeleteKey("CurLevel");
        foreach (DialoguesDataSO s in dialoguesDataSOs)
        {
            foreach (DialogueData p in s.DialogueData)
            {
                p.AlreadyBeen = false;
            }
        }
    }
}
