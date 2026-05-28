using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Data", menuName = "Levels/SceneInfo", order = 1)]
public class MissionSO : ScriptableObject
{
    [SerializeField] public int missionId;
    [SerializeField] public string missionName;
    [SerializeField] public string missionDescription;
    [SerializeField] public string missionDate;
    [SerializeField] public VideoClip missionVideo;
    
}
