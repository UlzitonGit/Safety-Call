using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayerMask;
    [SerializeField] private LayerMask _floorLayerMask;
    [SerializeField] private float _viewRange;
    [SerializeField] private float _angle = 60;
    void FixedUpdate()
    {
        FindEnemy();
    }

    public void FindEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _viewRange,  _enemyLayerMask);
        print(enemies.Length);
        if (enemies.Length > 0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                Vector2 direction = (enemies[i].transform.position - transform.position).normalized;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _viewRange, ~_floorLayerMask);
                Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow); 
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Enemy")
                    {
                        hit.transform.GetComponent<EnemyVisibility>().ShowEnemy();
                    }
                }
            }
        }
    }
}
