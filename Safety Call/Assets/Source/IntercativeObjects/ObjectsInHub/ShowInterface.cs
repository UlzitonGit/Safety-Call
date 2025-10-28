using UnityEngine;

namespace Source.IntercativeObjects.ObjectsInHub
{
    public class ShowInterface : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _clue;

        private bool _canInteract = false;
        // need new input system  \/\/\/
        private void Update()
        {
            if (_canInteract && Input.GetKeyDown(KeyCode.E))
            {
                _panel.SetActive(true);
            }
        }
            
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                _clue.SetActive(true);
                _canInteract = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                _clue.SetActive(false);
                _canInteract = false;
            }
        }
    }
}
