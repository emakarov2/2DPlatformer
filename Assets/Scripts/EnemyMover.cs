using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private Rigidbody2D _rigidbody;

    private float _defaultSpeed;

    private void Start()
    {
        _defaultSpeed = _speed;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveToTarget(Vector2 target)
    {
        //transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
        Vector2 movementDirection = (target - (Vector2)transform.position).normalized;

        _rigidbody.velocity = movementDirection * _speed;
    }

    public void Stop()
    {
        _speed = 0.0f;
    }

     public void Continue()
    {
        _speed = _defaultSpeed;
    }
}