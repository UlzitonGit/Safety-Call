using System;
using UnityEngine;

public class UiDamageShower : MonoBehaviour
{
    [SerializeField] private Animator _damageAnimator;
    [SerializeField] private ParticleSystem _damageParticles;
    [SerializeField] private ParticleSystem _rainParticleSystem;
    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private Camera _camera;

    private void Start()
    {
        Zoom();
    }

    public void GetDamage()
    {
        _damageAnimator.SetTrigger("Damage");
        _damageParticles.Play();
    }

    public void Zoom()
    {
        foreach (ParticleSystem particleSystem in _particleSystems)
        {
            var particleSystemShape = particleSystem.shape;
            particleSystemShape.scale = new Vector3(4 * _camera.orthographicSize, 2 * _camera.orthographicSize, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rain"))
        {
            _rainParticleSystem.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Rain"))
        {
            _rainParticleSystem.Stop();
        }
    }
}
