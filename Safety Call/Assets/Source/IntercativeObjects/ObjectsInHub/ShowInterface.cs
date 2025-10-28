using UnityEngine;

namespace Source.IntercativeObjects.ObjectsInHub
{
    public class ShowInterface : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _clue;

        // need new input system  \/\/\/
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _panel.SetActive(true);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                _clue.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                _clue.SetActive(false);
            }
        }
    }
}
