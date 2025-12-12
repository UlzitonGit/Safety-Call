using UnityEngine;

public class ShopLevel : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("CurLevel", 1);
    }
}
