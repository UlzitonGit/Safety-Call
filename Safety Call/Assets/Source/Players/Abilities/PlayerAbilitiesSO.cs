using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AbilityIconsList", menuName = "Game/Ability Icons List")]
public class PlayerAbilitiesSO : ScriptableObject
{
    public List<Sprite> abilities = new List<Sprite>();
    public List<string> info = new List<string>();

    public string GetDescription(int index)
    {
        return info[index];
    }

    public Sprite GetIcon(int index)
    {
        return abilities[index];
    }
}