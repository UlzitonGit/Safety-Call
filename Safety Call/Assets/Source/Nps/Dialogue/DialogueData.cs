using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class DialogueData
{
    [field:SerializeField] public List<PhraseData> Phrase {  get; private set; }
    [field: SerializeField] private static bool _alreadyBeen;
    public bool AlreadyBeen = _alreadyBeen;
}
