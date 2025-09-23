using System.Collections.Generic;
using UnityEngine;

namespace Source.Players
{
    public class PlayerSpotlighter : MonoBehaviour
    {
        [SerializeField] private GameObject[] _playerLights;

        public void SetChosenPlayer(List<int> index)
        {
            foreach (GameObject light in _playerLights)
            {
                if(light != null)
                    light.SetActive(false);
            }
            foreach (int playerIndex in index)
            {
                _playerLights[playerIndex].gameObject.SetActive(true);
            }
        }
    }
}
