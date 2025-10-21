using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;

    private SpriteRenderer _spriteRenderer;
    private bool _isGrounded;

    public event Action<bool> GroungingChandeg;

    public bool IsGrounded
    {
        get => _isGrounded;

        private set
        {
            if (_isGrounded != value)
            {
                _isGrounded = value;
                GroungingChandeg?.Invoke(value);
            }
        }
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        IsGrounded = CheckGrounding();
    }

    private bool CheckGrounding()
    {
        float horizontalSize = 0.8f;
        float verticalSize = 0.1f;
        float castDistance = 0.2f;
        float angle = 0f;

        float playerHalfHeight = _spriteRenderer.bounds.size.y / 2;

        Vector2 startPoint = transform.position + Vector3.down * playerHalfHeight;
        Vector2 box = new Vector2(horizontalSize, verticalSize);

        RaycastHit2D hit = Physics2D.BoxCast(
            startPoint,
            box,
            angle,
            Vector2.down,
            castDistance,
            _groundLayer
            );

        return hit.collider != null;
    }
}
