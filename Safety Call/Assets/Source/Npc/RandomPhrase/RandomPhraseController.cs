using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomPhraseController : MonoBehaviour
{
    [SerializeField] private float _minCooldown = 10;
    [SerializeField] private float _maxCooldown = 30;
    [SerializeField] private List<NpcRandomPhrase> _listNps;

    private void Start()
    {
        StartCoroutine(PhraseCooldown());
    }

    public IEnumerator PhraseCooldown()
    {
        yield return new WaitForSeconds(Random.Range(_minCooldown, _maxCooldown));
        ChooseNps().ShowRandomPhrase();
    }

    private NpcRandomPhrase ChooseNps()
    {
        var curListNps = new List<NpcRandomPhrase>();
        foreach (var n in _listNps)
        {
            if (!n.InDialogue)
                curListNps.Add(n);
        }
        return curListNps[Random.Range(0, _listNps.Count - 1)];
    }
}
