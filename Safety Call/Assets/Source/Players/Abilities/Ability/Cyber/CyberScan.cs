using System;
using UnityEngine;

public class CyberScan : AbilityBase
{
    [SerializeField] private bool isTutorial;
    private Scannable[] scans;
    
    private void Start()
    {
        scans = FindObjectsByType<Scannable>(FindObjectsSortMode.None);
    }

    public override void UseAbility()
    {
        foreach (Scannable scan in scans)
        {
            scan.Show();
        }

        if (isTutorial)
        {
            FindAnyObjectByType<TutorialController>().CheckScan();
        }
    }
}
