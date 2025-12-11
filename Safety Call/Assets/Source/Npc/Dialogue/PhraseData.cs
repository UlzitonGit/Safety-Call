using System;
using UnityEngine;

[Serializable]
public class PhraseData
{
    [TextArea(3, 5)][SerializeField] public string Phrase;
    [field: SerializeField] public TalkerType Talker { get; private set; }
    [field: SerializeField] public Sprite CharacterIcon { get; private set; }
}

public enum TalkerType
{
    Eve = 0,
    Suber = 1,
    Laska = 2,
    Beast = 3,
    Asahi = 4
}