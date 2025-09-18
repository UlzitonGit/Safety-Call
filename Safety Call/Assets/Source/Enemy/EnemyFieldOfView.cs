using Source.Players.Behaviour;
using UnityEngine;

public class EnemyFieldOfView : FieldOfView
{
    [SerializeField] private GunfightBehaviourManager _enemyGunfightBehaviourManager;

    [SerializeField] private EnemyVisibility _enemyVisibility;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        viewAngle = 90;
        viewRadius = 15;
    }

    private void FixedUpdate()
    {
        FindVisibleTargets();
    }

    protected override void ActionViewedObject(Transform target)
    {
        PlayerStates player = target.GetComponent<PlayerStates>();
        print(player.transform.name);
        player.SetVisible(true);
        _enemyVisibility.ShowEnemy();
        _enemyGunfightBehaviourManager.AddEnemyTarget(player);
    }
}
