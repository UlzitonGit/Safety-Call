using Source.Enemy;
using UnityEngine;

public class FourthRoom : MonoBehaviour
{
    [SerializeField] private AutomaticDoor automaticDoor;
    [SerializeField] private EnemyHealth enemyHealth;

    void Update()
    {
        if (enemyHealth != null)
        {
            if (enemyHealth.CurrentHealth <= 0)
            {
                automaticDoor.SetIsActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemyHealth = collision.GetComponent<EnemyHealth>();
        }
    }
}
