using System.Collections;
using UnityEngine;

public class Scannable : MonoBehaviour
{
    [SerializeField] private GameObject scan;

    public void Show()
    {
        StartCoroutine(Scan());
    }

    IEnumerator Scan()
    {
        scan.SetActive(true);
        yield return new WaitForSeconds(5f);
        scan.SetActive(false);
    }
}
