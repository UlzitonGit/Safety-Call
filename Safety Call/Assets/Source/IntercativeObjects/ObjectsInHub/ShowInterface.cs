using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.IntercativeObjects.ObjectsInHub
{
    public class ShowInterface : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _hint;

        private InputAction _interactAction;

        private bool _canInteract = true;

        public void SetCanInteract(bool value)
        {
            _canInteract = value;
            _hint.SetActive(value);
        }
        public void DoInteract()
        {
            if (_canInteract)
            {
                _panel.SetActive(true);
            }
        }
            
        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && _canInteract)
            {
                _hint.SetActive(true);
            }
        }

        protected void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && _canInteract)
            {
                _hint.SetActive(false);
            }
        }
    }
}
