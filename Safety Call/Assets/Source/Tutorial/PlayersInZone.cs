using System.Collections.Generic;
using UnityEngine;

public class PlayersInZone : MonoBehaviour
{
    [SerializeField] private int numRoom;
    [SerializeField] private int needPlayers;
    [SerializeField] private AutomaticDoor automaticDoor;
    [SerializeField] private bool needOpen;
    [SerializeField] private TutorialController tutorialController;
    private List<GameObject> _curPlayers = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!_curPlayers.Contains(collision.gameObject))
            {
                _curPlayers.Add(collision.gameObject);
                if (_curPlayers.Count == needPlayers)
                {
                    automaticDoor.SetIsActive(needOpen);
                    tutorialController.SetRoom(numRoom);
                }
            }
        }
    }
}
