using Source.Core;
using UnityEngine;

public class MissionBootstrapper : MonoBehaviour
{
    private void Awake()
    {
        InputManager.Instance.SwitchActionMapType(ActionMapType.MissionController);
    }
}
