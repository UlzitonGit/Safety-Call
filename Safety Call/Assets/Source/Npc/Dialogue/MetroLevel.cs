using UnityEngine;

public class MetroLevel : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("CurLevel", 2);
    }
}
