using System;
using UnityEngine;
using UnityEngine.Rendering;

public class TimeStopManager : MonoBehaviour
{
    [SerializeField] private Volume _volume;
    [SerializeField] private FieldOfView[] _fieldOfViews;
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
        foreach (var fieldOfView in _fieldOfViews)
        {
            fieldOfView.DrawTriangle();
        }
        Time.timeScale = 0;
        _volume.weight = _volumeWeight;
    }

    private void PlayTime()
    {
        _isStoped = false;
        foreach (var fieldOfView in _fieldOfViews)
        {
            fieldOfView.HideTriangle();
        }
        Time.timeScale = 1;
        _volume.weight = 0f;
    }
}
