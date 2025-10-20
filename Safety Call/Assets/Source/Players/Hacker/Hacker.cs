using System;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private bool _collidingRCP;

    private RemoteControlePanel _controlePanel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _collidingRCP)
        {
            _controlePanel.Hack();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RemoteControl"))
        {
            other.TryGetComponent<RemoteControlePanel>(out _controlePanel);
            
            _collidingRCP = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("RemoteControl"))
        {
            _controlePanel = null;
            _collidingRCP = false;
        }
    }
}
