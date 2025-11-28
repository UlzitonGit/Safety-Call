using System;
using UnityEngine;

[Serializable]
public class PhraseData
{
    [field:SerializeField] public string Phrase {  get; private set; }
    [field: SerializeField] public TalkerType Talker { get; private set; }
}

public enum TalkerType
{
    Player = 0,
    Npc = 1
}