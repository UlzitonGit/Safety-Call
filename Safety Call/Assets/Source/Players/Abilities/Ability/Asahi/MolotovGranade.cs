using UnityEngine;

public class MolotovGranade : AbilityBase
{
    [SerializeField] private GranadeAbstract _granade;
    [SerializeField] private Transform _spawnPoint;
    public override void UseAbility()
    {
        if(_usageCount == 0 || !CanBeUsed) return;
        _usageCount -= 1;
        GranadeAbstract _currentGranade = Instantiate(_granade, _spawnPoint.position, _spawnPoint.localRotation);
        _currentGranade.Throw();
    }
}
