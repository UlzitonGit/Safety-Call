using UnityEngine;

public class WeaponSoundPlayer : MonoBehaviour
{
    [SerializeField] private float[] _pithDensity;
    
    [SerializeField] private AudioClip _shotSound;
    [SerializeField] private AudioSource _soundSource;

    public void PlayShootSound()
    {
        _soundSource.pitch = Random.Range(_pithDensity[0], _pithDensity[1]);
        _soundSource.PlayOneShot(_shotSound);
    }
}
