using System.Collections;
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

        public override void GetDamage(float damage, Vector3 enemyPos)
        {
            base.GetDamage(damage, enemyPos);
            StartCoroutine(LookAtTarget(enemyPos));
        }
        IEnumerator LookAtTarget(Vector3 enemyPos)
        {
            yield return new WaitForSeconds(_timeToReaction);
            _creaturesData._playerMovement.LookAtTarget(enemyPos);
        }

        protected override void Death()
        {
            base.Death();
            _gameplayStagesManager.EnemyKilled();
            _playerAnimator.Death();
            _enemyStates.SetAlive(_isAlive);
        }
    }
}
