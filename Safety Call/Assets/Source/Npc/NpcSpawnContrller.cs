using UnityEngine;
using System.Collections.Generic;

public class NpcSpawnContrller : MonoBehaviour
{
    [Header("Laska")]
    [SerializeField] private GameObject laska;
    [SerializeField] private List<GameObject> laskaSpawnList = new List<GameObject>();
    [Header("Cyber")]
    [SerializeField] private GameObject cuber;
    [SerializeField] private List<GameObject> cuberSpawnList = new List<GameObject>();
    [Header("Asahi")]
    [SerializeField] private GameObject asahi;
    [SerializeField] private List<GameObject> asahiSpawnList = new List<GameObject>();
    [Header("Beast")]
    [SerializeField] private GameObject beast;
    [SerializeField] private List<GameObject> beastSpawnList = new List<GameObject>();

    private void Start()
    {
        laska.transform.position = laskaSpawnList[PlayerPrefs.GetInt("CurLevel")].transform.position;
        cuber.transform.position = cuberSpawnList[PlayerPrefs.GetInt("CurLevel")].transform.position;
        asahi.transform.position = asahiSpawnList[PlayerPrefs.GetInt("CurLevel")].transform.position;
        beast.transform.position = beastSpawnList[PlayerPrefs.GetInt("CurLevel")].transform.position;
    }
}
