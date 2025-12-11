using Source.Enemy;
using System.Collections.Generic;
using UnityEngine;

public class KillToEscape : MonoBehaviour
{
    [SerializeField] private List<DartboardHealth> dartboards;
    [SerializeField] private AutomaticDoor automaticDoor;

    void Update()
    {
        int dieDartboard = 0;
        foreach (DartboardHealth e in dartboards)
        {
            if (e.CurrentHealth <= 0)
                dieDartboard++;
        }
        if (dieDartboard == dartboards.Count)
        {
            automaticDoor.SetIsActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
