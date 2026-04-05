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
        

        public void DoInteract()
        {
            if (_canInteract)
            {
                _panel.SetActive(true);
            }
        }
            
        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _hint.SetActive(true);
                collision.GetComponent<PlayerInteraction>().SetInteractable(this);
            }
        }

        protected void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") )
            {
                _hint.SetActive(false);
                collision.GetComponent<PlayerInteraction>().SetInteractable(null);
            }
        }
    }
}
