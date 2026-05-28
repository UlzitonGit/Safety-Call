using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MissonSelectionController : MonoBehaviour
{
    [SerializeField] private StartMission startMission;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI date;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private MissionSO[] mission;
    private int currentMissionIndex = 0;
    
    public void ShowInfo(int missionId)
    {
        currentMissionIndex = mission[missionId].missionId;
        description.text = mission[missionId].missionDescription;
        name.text = mission[missionId].missionName;
        date.text = mission[missionId].missionDate;
        videoPlayer.clip = mission[missionId].missionVideo;
    }

    public void StartMission()
    {
        startMission.OnMissionScene(currentMissionIndex);
    }
}
