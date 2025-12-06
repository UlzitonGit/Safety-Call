using System.Collections;
using TMPro;
using UnityEngine;

public class EndGamePanelUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private GameObject _quitButton;
    

    public void ShowResults(int scoreGained, int scoreMax)
    {
        StartCoroutine(ShowingResults(scoreGained, scoreMax));
    }
    
    IEnumerator ShowingResults(int scoreGained, int scoreMax)
    {
        yield return new WaitForSeconds(1);
        _scoreText.gameObject.SetActive(true);
        string scoreText = scoreGained.ToString() + " / " + scoreMax.ToString();
        foreach (var text in scoreText)
        {
            _scoreText.text += text;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        _quitButton.SetActive(true);
        
    }
}
