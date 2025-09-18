using Source.Creatures.Health;
using UnityEngine;

namespace Source.Enemy
{
    public class EnemyHealth : CreatureHealth
    {
        private EnemyStates _enemyStates;
        protected override void Start()
        {
            base.Start();
            _enemyStates = GetComponent<EnemyStates>();
        }

        protected override void Death()
        {
            base.Death();
            _enemyStates.SetAlive(_isAlive);
            Destroy(gameObject);
        }
    }
}
