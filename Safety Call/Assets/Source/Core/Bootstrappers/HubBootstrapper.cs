using Source.Core;
using UnityEngine;

public class HubBootstrapper : MonoBehaviour
{
    private void Awake()
    {
        InputManager.Instance.SwitchActionMapType(ActionMapType.HubController);
    }
}
