using UnityEngine;
using UnityEngine.Events;

public class HintOnTrigger : MonoBehaviour
{
    public UnityEvent TriggerEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            print("invoke by trigger");
            TriggerEvent?.Invoke();
    }

}
