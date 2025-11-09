using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.IntercativeObjects.ObjectsInHub
{
    public class ShowInterface : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _clue;

        private InputAction _interactAction;

        private bool _canInteract = false;

        private void OnEnable()
        {
            _interactAction = InputManager.Instance.GameInput.Hub.Interact;
            _interactAction.performed += DoInteract;
        }

        private void OnDisable()
        {;
            _interactAction.performed -= DoInteract;
        }

        private void DoInteract(InputAction.CallbackContext ctx)
        {
            if (_canInteract)
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
