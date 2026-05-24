using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoofVisibility : MonoBehaviour
{
    [SerializeField] private TilemapRenderer _tilemapRenderer;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _tilemapRenderer.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _tilemapRenderer.enabled = true;
        }
    }
}
