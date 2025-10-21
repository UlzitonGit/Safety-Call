using Source.Creatures.Health;

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
            _gameplayStagesManager.EnemyKilled();
            _enemyStates.SetAlive(_isAlive);
        }
    }
}
