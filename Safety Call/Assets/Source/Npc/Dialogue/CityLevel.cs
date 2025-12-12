using UnityEngine;

public class CityLevel : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("CurLevel", 3);
    }
}
