using System.Collections;
using TMPro;
using UnityEngine;

public class NpcRandomPhrase : MonoBehaviour
{
    [SerializeField] private float showTime;
    [SerializeField] private AllPhrasesSO phrases;
    [SerializeField] private GameObject phraseObj;
    [SerializeField] private TextMeshProUGUI phraseText;
    [SerializeField] private RandomPhraseController phraseController;

    private AnimatedText _phraseAnim;

    public bool InDialogue = false;

    private void Start()
    {
        _phraseAnim = phraseText.GetComponent<AnimatedText>();
    }

    public void ShowRandomPhrase()
    {
        phraseText.text = phrases.GetRandomPhrase();
        phraseObj.SetActive(true);
        _phraseAnim.StartPrintText();
        StartCoroutine(HideRandomPhrase());
    }

    private IEnumerator HideRandomPhrase()
    {
        yield return new WaitForSeconds(showTime);
        phraseObj.SetActive(false);
        StartCoroutine(phraseController.PhraseCooldown());
    }
}
