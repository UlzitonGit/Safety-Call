using UnityEngine;

public class PlayerPolice : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private PlayerData _playerData;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _playerData._PlayerGunfightBehaviour._isControlling)
        {
            CheckPlayersToRevive();
        }
    }

    private void CheckPlayersToRevive()
    {
        Collider2D[] claymores = Physics2D.OverlapCircleAll(transform.position, 2, _layerMask);
        print("tryFind");
        foreach (Collider2D claymore in claymores)
        {
            print(claymore.gameObject.name);
            Claymore claymoreComponent = claymore.GetComponentInChildren<Claymore>();
            claymoreComponent.Deactivate();
        }
    }
}
