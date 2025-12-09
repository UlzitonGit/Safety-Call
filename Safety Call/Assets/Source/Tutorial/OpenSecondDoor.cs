using UnityEngine;

public class OpenSecondDoor : MonoBehaviour
{
    [SerializeField] private AutomaticDoor automaticDoor;

    public void Open()
    {
        automaticDoor.SetIsActive(true);
    }
}
