using System.Collections.Generic;
using Unity.Properties;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Phrases", menuName = "NpsSO/Phrases")]
public class PhrasesSO : ScriptableObject
{
    [TextArea(5, 20)][SerializeField] private string _phrase;
    [SerializeField] public List<string> Phrases;

    public string GetRandomPhrase()
    {
        if (Phrases.Count == 0)
            return string.Empty;

        return Phrases[Random.Range(0, Phrases.Count)];
    }
}

/*[CustomEditor(typeof(PhrasesSO))]
[CanEditMultipleObjects]
[ExecuteInEditMode]
public class PhrasesSOCostomEditor : Editor
{
    private SerializedProperty _phraseProperty;
    private SerializedProperty _phrasesProperty;

    private bool _addPhrases;

    private void OnEnable()
    {
        _phraseProperty = serializedObject.FindProperty("_phrase");
        _phrasesProperty = serializedObject.FindProperty("Phrases");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_phraseProperty);

        EditorGUILayout.PropertyField(_phrasesProperty, new GUIContent());

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add phrase"))
        {
            _addPhrases = true;
        }

        if (_addPhrases)
        {
            AddCurrentPhraseToList();
        }

        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }

    private void AddCurrentPhraseToList()
    {
        string currentPhrase = _phraseProperty.stringValue;

        if (!string.IsNullOrEmpty(currentPhrase))
        {
            _phrasesProperty.arraySize++;
            SerializedProperty newElement = _phrasesProperty.GetArrayElementAtIndex(_phrasesProperty.arraySize - 1);
            newElement.stringValue = currentPhrase;

            _phraseProperty.stringValue = string.Empty;

        }
        _addPhrases = false;
    }
}*/