using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogues", menuName = "NpsSO/Dialogues")]
public class DialoguesDataSO : ScriptableObject
{
    [field:SerializeField] public List<DialogueData> DialogueData {  get; private set; }
}
