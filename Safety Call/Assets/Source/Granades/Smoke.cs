using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : GranadeAbstract
{
    [SerializeField] private ParticleSystem _smokeParticles;
    [SerializeField] private GameObject _smokeZone;
    protected override List<CreatureStates> Detonate()
    {
        _smokeParticles.Play();
        return null;
    }

    protected override void ActionTargets(List<CreatureStates> targets)
    {
        _smokeZone.SetActive(true);
        _smokeParticles.Play();
        StartCoroutine(DestroyGranade());
    }

    IEnumerator DestroyGranade()
    {
        yield return new WaitForSeconds(25);
        _smokeZone.SetActive(false);
        Destroy(gameObject);
    }
}
