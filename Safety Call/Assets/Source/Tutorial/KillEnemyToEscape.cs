using Source.Enemy;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemyToEscape : MonoBehaviour
{
    [SerializeField] private int needDeathEnemy;
    [SerializeField] private AutomaticDoor automaticDoor;
    [SerializeField] private List<EnemyHealth> enemysHealth;
    private bool _playerInRoom = false;

    void Update()
    {
        if (_playerInRoom)
        {
            if (enemysHealth.Count == needDeathEnemy)
            {
                int dieEnemy = 0;
                foreach (EnemyHealth e in enemysHealth)
                {
                    if (e.CurrentHealth <= 0)
                        dieEnemy++;
                }
                if (dieEnemy == needDeathEnemy)
                {
                    automaticDoor.SetIsActive(true);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            print(collision);
            if (enemysHealth.Contains(collision.GetComponent<EnemyHealth>()))
            enemysHealth.Add(collision.GetComponent<EnemyHealth>());
        }
        if (collision.tag == "Player") 
            _playerInRoom = true;
    }
}
