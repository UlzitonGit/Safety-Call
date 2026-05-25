using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class RoofVisibility : MonoBehaviour
{
    [SerializeField] private TilemapRenderer _tilemapRenderer;
    private ShadowCaster2D _shadowCaster2D;

    private void Start()
    {
        ShadowCaster2D component;
        TryGetComponent<ShadowCaster2D>(out component);
        _shadowCaster2D = component;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _tilemapRenderer.enabled = false;
            if (_shadowCaster2D != null)
            {
                _shadowCaster2D.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _tilemapRenderer.enabled = true;
            if (_shadowCaster2D != null)
            {
                _shadowCaster2D.enabled = true;
            }
        }
    }
}
