using Source.Creatures.Health;
using UnityEngine;

public class BeastPassive : MonoBehaviour
{
    [SerializeField] private float _defence;
    [SerializeField] private CreatureHealth _creatureHealth;
    void Start()
    {
        _creatureHealth.SetDefence(_defence);
    }

}
