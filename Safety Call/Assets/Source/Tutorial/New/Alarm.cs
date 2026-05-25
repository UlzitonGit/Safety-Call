using UnityEngine;

public class Alarm : MonoBehaviour, IHackable
{
    [SerializeField] private GlobalEnemyActionController globalEnemyActionController;

    public void Hack()
    {
        globalEnemyActionController.MoveClosestEnemies(transform.position, transform.position);
    }
}
