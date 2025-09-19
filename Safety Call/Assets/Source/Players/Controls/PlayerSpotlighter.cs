using UnityEngine;

namespace Source.Players
{
    public class PlayerSpotlighter : MonoBehaviour
    {
        [SerializeField] private GameObject[] _playerLights;

        public void SetChosenPlayer(int index)
        {
            for (int i = 0; i < _playerLights.Length; i++)
            {
                if (_playerLights[i] != null)
                {
                    if(i == index) _playerLights[i].SetActive(true);
                    else _playerLights[i].SetActive(false);
                }
            }
        }
    }
}
