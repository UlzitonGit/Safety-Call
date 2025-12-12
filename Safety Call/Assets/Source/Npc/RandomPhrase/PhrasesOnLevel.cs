using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class PhrasesOnLevel
{
    [SerializeField] public List<string> Phrases;
    public int Level = 0;
}
