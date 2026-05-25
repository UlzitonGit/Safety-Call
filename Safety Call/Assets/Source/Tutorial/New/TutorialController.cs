using System;
using Source.Players.Controls;
using UnityEngine;
using Object = System.Object;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialStages;
    [SerializeField] private PlayerChooser playerChooser;
    [SerializeField] private PlayerData cyber;
    private int dialogIndex;
    private bool cyberPicked = false;

    private void Update()
    {
        if (tutorialStages[dialogIndex].name == "Tutorial (4)" && playerChooser.GetPlayersChosen() == 1 &&
            playerChooser.GetChosenPlayers()[0] == cyber && !cyberPicked)
        {
            cyberPicked = true;
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
        SetTime(0);
    }

    public void SetTime(int time)
    {
        Time.timeScale = time;
    }
}
