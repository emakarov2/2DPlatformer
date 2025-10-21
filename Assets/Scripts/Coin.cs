using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] protected string playerTag = "Player";

    protected bool isCollected = false;
    protected Collider2D trigger;

    protected virtual void Start()
    {
        trigger = GetComponent<Collider2D>();
        trigger.isTrigger = true;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if ((isCollected == false) && other.CompareTag(playerTag))
        {
            Collect();
        }
    }

    public virtual void Collect()
    {
        if (isCollected) 
        {
            return;
        }
        
        isCollected = true;
        OnCollected();
    }

    protected virtual void OnCollected()
    {
        Destroy(gameObject);
    }
}