using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PhraseData
{
    [field:SerializeField] public string Phrase {  get; private set; }
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