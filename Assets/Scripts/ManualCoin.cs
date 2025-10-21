using UnityEngine;

public class ManualCoin : Coin
{
    [SerializeField] private KeyCode collectKey = KeyCode.E;

    private bool _isPlayerNear = false;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if(_isPlayerNear && Input.GetKeyDown(collectKey) && isCollected == false)
        {
            Collect();
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if ((isCollected == false) && other.CompareTag(playerTag))
        {
            _isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((isCollected == false) && other.CompareTag(playerTag))
        {
            _isPlayerNear = false;
        }
    }
}