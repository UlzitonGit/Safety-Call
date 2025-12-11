using Source.Core;
using UnityEngine;

public class TutorialSafeZone : MonoBehaviour
{
    [SerializeField] private GameObject endPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hostage"))
        {
            other.gameObject.SetActive(false);
            Time.timeScale = 0;
            endPanel.SetActive(true);
            InputManager.Instance.SwitchActionMapType(ActionMapType.UI);
        }
    }
}
