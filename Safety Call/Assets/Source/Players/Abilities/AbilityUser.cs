using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUser : MonoBehaviour
{
    [SerializeField] public List<AbilityBase> _abilities = new List<AbilityBase>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _abilities[0].CanBeUsed)
        {
            _abilities[0].UseAbility();
        }
        if (Input.GetKeyDown(KeyCode.D) && _abilities[1].CanBeUsed)
        {
            _abilities[1].UseAbility();
        }
    }
}
