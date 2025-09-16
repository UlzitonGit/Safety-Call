using System;
using UnityEngine;
using UnityEngine.Rendering;

public class TimeStopManager : MonoBehaviour
{
    [SerializeField] private Volume _volume;
    
    private float _volumeWeight = 0.7f;
    private bool _isStoped;

    private void Update()
    {
        if (!_isStoped && Input.GetKeyDown(KeyCode.Space))
        {
            StopTime();
        }
        else if (_isStoped && Input.GetKeyDown(KeyCode.Space))
        {
            PlayTime();
        }
    }

    private void StopTime()
    {
        _isStoped = true;
        
        Time.timeScale = 0.05f;
        _volume.weight = _volumeWeight;
    }

    private void PlayTime()
    {
        _isStoped = false;
        
        Time.timeScale = 1;
        _volume.weight = 0f;
    }
}
