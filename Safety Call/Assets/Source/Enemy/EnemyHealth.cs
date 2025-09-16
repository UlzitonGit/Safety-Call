using Source.Creatures.Health;
using UnityEngine;

namespace Source.Enemy
{
    public class EnemyHealth : CreatureHealth
    {
        protected override void Death()
        {
            base.Death();
            Destroy(gameObject);
        }
    }
}
