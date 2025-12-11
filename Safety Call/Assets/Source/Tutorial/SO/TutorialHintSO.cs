using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TutorialHintSO", menuName = "Scriptable Objects/TutorialHintSO")]
public class TutorialHintSO : ScriptableObject
{
    [field: SerializeField] public List<TutorialHintPage> TutorialHintsPages { get; private set; }
}

[Serializable]
public class TutorialHintPage
{
    [field: SerializeField] public List<TutorialHint> TutorialHints { get; private set; }
    [field: SerializeField] private static bool _alreadyBeen;
    public bool AlreadyBeen = _alreadyBeen;
}

[Serializable]
public class TutorialHint
{
    [TextArea(3, 5)][SerializeField] public string HintText;
    [field: SerializeField] public Sprite HintSprite { get; private set; }
}
