using System;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControlePanel : MonoBehaviour, IHackable
{
    [SerializeField] private GameObject[] _connectedHackables;
    
    private List<IHackable> _hackables = new List<IHackable>();
    private bool _isHacked = false;
    

    private void Start()
    {
        foreach (var item in _connectedHackables)
        {
            _hackables.Add(item.GetComponent<IHackable>());
        }
    }

    public void Hack()
    {
        _isHacked=true;
        foreach (var hackable in _hackables)
        {
            print("hackable");
            hackable.Hack();
        }
    }

    public bool IsHacked()
    {
        return _isHacked;
    }
}
