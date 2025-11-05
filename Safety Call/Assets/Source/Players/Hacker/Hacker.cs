using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hacker : ASpecialAbility
{
    private bool _collidingRCP;

    private RemoteControlePanel _controlePanel;

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

    protected override void DoAbility(InputAction.CallbackContext ctx)
    {
        if (_collidingRCP)
        {
            _controlePanel.Hack();
        }
    }
}
