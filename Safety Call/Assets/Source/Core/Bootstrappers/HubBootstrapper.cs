using Source.Core;
using UnityEngine;

public class HubBootstrapper : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("CurLevel"))
        {
            PlayerPrefs.SetInt("CurLevel", 0);
        }

        InputManager.Instance.SwitchActionMapType(ActionMapType.HubController);
    }
}
