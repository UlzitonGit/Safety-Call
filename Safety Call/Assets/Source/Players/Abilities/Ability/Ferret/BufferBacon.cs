using System;
using UnityEngine;
using UnityEngine.AI;

public class BufferBacon : MonoBehaviour
{
    [SerializeField] private float _multiplier = 1.3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerData agent;
            other.TryGetComponent<PlayerData>(out agent);
            agent._playerMovement.SetSpeed(agent._playerMovement.GetAgentSpeed() * _multiplier);
            agent._PlayerWeaponController.GetWeapon().SetDamage(agent._PlayerWeaponController.GetWeapon().GetDamage() * _multiplier);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerData agent;
            other.TryGetComponent<PlayerData>(out agent);
            agent._playerMovement.SetSpeed(agent._playerMovement.GetAgentSpeed() / _multiplier);
            agent._PlayerWeaponController.GetWeapon().SetDamage(agent._PlayerWeaponController.GetWeapon().GetDamage() / _multiplier);
        }
    }
}
