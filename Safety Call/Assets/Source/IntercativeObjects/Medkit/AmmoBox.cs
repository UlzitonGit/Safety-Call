using UnityEngine;

public class AmmoBox : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject hint;
    [SerializeField] protected int ammoToAdd;
    private bool _isUsed = false;
    private WeaponGeneral _weapon;
    
    

    public void DoInteract()
    {
        if (!_isUsed)
        {
            if (_weapon != null)
            {
                _weapon.SetMaxAmmo(ammoToAdd);
                Destroy(gameObject);
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hint.SetActive(true);
            collision.GetComponent<PlayerInteraction>().SetInteractable(this);
            _weapon = collision.GetComponentInChildren<WeaponGeneral>();
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            hint.SetActive(false);
            collision.GetComponent<PlayerInteraction>().SetInteractable(null);
        }
    }

}
