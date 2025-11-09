using System.Collections;
using TMPro;
using UnityEngine;

public class NpsRandomPhrase : MonoBehaviour
{
    [SerializeField] private float _showTime;
    [SerializeField] private PhrasesSO _phrases;
    [SerializeField] private GameObject _phraseObj;
    [SerializeField] private TextMeshProUGUI _phraseText;
    [SerializeField] private RandomPhraseController _phraseController;

    public bool InDialogue { get; private set; } = false;

    public void ShowRandomPhrase()
    {
        _phraseText.text = _phrases.GetRandomPhrase();
        _phraseObj.SetActive(true);
        StartCoroutine(HideRandomPhrase());
    }

    private IEnumerator HideRandomPhrase()
    {
        yield return new WaitForSeconds(_showTime);
        _phraseObj.SetActive(false);
        StartCoroutine(_phraseController.PhraseCooldown());
    }
}
