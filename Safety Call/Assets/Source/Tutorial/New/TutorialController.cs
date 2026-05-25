using System;
using System.Collections;
using Source.Players.Controls;
using UnityEngine;
using Object = System.Object;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialStages;
    [SerializeField] private PlayerChooser playerChooser;
    [SerializeField] private PlayerData cyber;
    [SerializeField] private GameObject pressHint;
    [SerializeField] private GameObject scanHint;
    [SerializeField] private GameObject hackHint;
    [SerializeField] private RemoteControlePanel remoteControlePanel;
    [SerializeField] private GameObject[] destroyHints;
    [SerializeField] private GameObject[] hostageHints;
    [SerializeField] private GameObject reviveHint;
    [SerializeField] private Alarm alarm;
    public bool checkCyberPicked;
    public bool cyberScan;
    private int dialogIndex;
    private bool cyberPicked = false;
    private bool hostagePicked = false;
    private bool destroyHint = false;
    private bool isRevived = false;

    private void Update()
    {
        if(cyberPicked) return;
        if (checkCyberPicked && playerChooser.GetPlayersChosen() == 1 &&
            playerChooser.GetChosenPlayers()[0] == cyber && !cyberPicked)
        {
            cyberPicked = true;
            pressHint.SetActive(false);
            NextStage();
        }
    }

    private void Start()
    {
        tutorialStages[0].GetComponent<IStartable>().StartAction();
    }
    
    public void NextStage()
    {
        dialogIndex++;
        if (dialogIndex >= tutorialStages.Length)
        {
            return;
        }
        tutorialStages[dialogIndex].GetComponent<IStartable>().StartAction();
        //SetTime(0);
    }

    public void SetTime(int time)
    {
        Time.timeScale = time;
    }

    public void SetPicked()
    {
        checkCyberPicked = true;
    }
    public void SetScan()
    {
        cyberScan = true;
    }
    public void CheckScan()
    {
        if (playerChooser.GetPlayersChosen() == 1 &&
            playerChooser.GetChosenPlayers()[0] == cyber && cyberScan)
        {
            remoteControlePanel.enabled = true;
            scanHint.SetActive(false);
            cyberScan = false;
            NextStage();
        }
    }

    public void Hack()
    {
        hackHint.SetActive(false);
        NextStage();
        StartCoroutine(EnemyInterest());
    }

    public void DestroyHints()
    {
        if(destroyHint) return;
        print("Destroy Hints");
        destroyHint = true;
        destroyHints[0].SetActive(false);
        destroyHints[1].SetActive(false);
        NextStage();
    }

    public void DestroyHostageHints()
    {
        if (!hostagePicked)
        {
            hostagePicked = true;
            hostageHints[0].SetActive(false);
            hostageHints[1].SetActive(false);
            NextStage();
        }
    }

    IEnumerator EnemyInterest()
    {
        yield return new WaitForSeconds(10);
        alarm.Hack();
    }

    public void Revived()
    {
        if(isRevived) return;
        isRevived = true;
        reviveHint.SetActive(false);
        NextStage();
    }
}
