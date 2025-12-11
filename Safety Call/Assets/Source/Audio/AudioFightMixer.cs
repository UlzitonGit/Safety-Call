using System.Collections;
using UnityEngine;

public class AudioFightMixer : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool _isFight;
    
    public void StartFightSong()
    {
        if (_isFight == true)
        {
            StopAllCoroutines();
        }
        animator.SetBool("IsFight", true);
        StartCoroutine(FightSong());
        _isFight = true;
    }

    IEnumerator FightSong()
    {
        yield return new WaitForSeconds(4f);
        animator.SetBool("IsFight", false);
    }
}
