using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Phrases", menuName = "NpsSO/Phrases")]
public class AllPhrasesSO : ScriptableObject
{
    [SerializeField] public List<PhrasesOnLevel> AllPhrases;

    public string GetRandomPhrase()
    {
        for (int i = 0; i < AllPhrases.Count; i ++)
        {
            if (AllPhrases[i].Level == PlayerPrefs.GetInt("CurLevel"))
            {
                return AllPhrases[i].Phrases[Random.Range(0, AllPhrases[i].Phrases.Count)];
            }
        }
        
        return string.Empty;
    }
}