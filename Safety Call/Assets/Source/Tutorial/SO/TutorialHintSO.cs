using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TutorialHintSO", menuName = "Scriptable Objects/TutorialHintSO")]
public class TutorialHintSO : ScriptableObject
{
    [field: SerializeField] public List<TutorialHint> tutorialHints { get; private set; }
}

[Serializable]
public class TutorialHint
{
    [field: SerializeField] public string HintText { get; private set; }
    [field: SerializeField] public Sprite HintSprite { get; private set; }
}
