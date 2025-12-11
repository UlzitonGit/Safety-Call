using UnityEngine;

public class SevenRoom : MonoBehaviour
{
    [SerializeField] private RemoteControlePanel controlePanel;
    [SerializeField] private Claymore claymore;
    [SerializeField] private AutomaticDoor automaticDoor;

    void Update()
    {
        if (controlePanel.IsHacked() && !claymore.IsActive())
        {
            automaticDoor.SetIsActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
