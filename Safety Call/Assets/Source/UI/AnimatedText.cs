using TMPro;
using System.Collections;
using UnityEngine;
using System.Runtime.CompilerServices;

public class AnimatedText : MonoBehaviour
{
    [SerializeField] private float speedText = 0.05f;
    private TextMeshProUGUI _text;
    private string _message;

    public bool IsPrinted {  get; private set; } = false;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void StartPrintText(string mes)
    {
        if (_text == null)
            _text = GetComponent<TextMeshProUGUI>();
        _message = mes;
        IsPrinted = false;
        _text.text = "";
        StartCoroutine(PrintText());
    }

    public void StartPrintText()
    {
        if (_text == null)
            _text = GetComponent<TextMeshProUGUI>();
        _message = _text.text;
        IsPrinted = false;
        _text.text = "";
        StartCoroutine(PrintText());
    }

    public void StopPrintText()
    {
        StopCoroutine(PrintText());
        _text.text = _message;
        IsPrinted = true;
    }

    private IEnumerator PrintText()
    {
        foreach (char c in _message)
        {
            _text.text += c;
            yield return new WaitForSeconds(speedText);
        }
        IsPrinted = true;
    }
}
