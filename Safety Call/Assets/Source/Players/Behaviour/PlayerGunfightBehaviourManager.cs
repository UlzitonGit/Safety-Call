using UnityEngine;

namespace Source.Players.Behaviour
{
    public class PlayerGunfightBehaviourManager : MonoBehaviour
    {
        [SerializeField] private bool _canShootFirst;
        
        private bool _isAbleToShoot;

        public void CheckShootingRelevation()
        {
            if (_canShootFirst == true)
            {
                _isAbleToShoot = true;
            }
        }

        public bool GetShootingRelevation()
        {
            return _isAbleToShoot;
        }
    }
}
