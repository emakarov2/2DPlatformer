using UnityEngine;

public abstract class BaseAnimator : MonoBehaviour
{
    [SerializeField] protected string _isRunning = "IsRunning";

    protected Animator _animator;
    protected SpriteRenderer _spriteRenderer;
    protected Rigidbody2D _rigidbody;

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        UpdateAnimations();
        OrientSprite();
    }

    protected abstract void UpdateAnimations();

    protected virtual void OrientSprite()
    {
        float direction = GetMovementDirection();

        if (direction > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (direction < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }

    protected abstract float GetMovementDirection();
}