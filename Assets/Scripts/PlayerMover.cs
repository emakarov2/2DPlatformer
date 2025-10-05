using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody;

    private float _moveInput;

    private bool _isGrounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveInput = Input.GetAxisRaw(Horizontal);

        _isGrounded = CheckGrounding();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        HorizontalMove();
    }

    private bool CheckGrounding()
    {
        float horizontalSize = 0.8f;
        float verticalSize = 0.1f;
        float castDistance = 0.2f;
        float angle = 0f;
        
        float playerHalfHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;

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


    private void HorizontalMove()
    {
        _rigidbody.velocity = new Vector2(_moveInput * _moveSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }

  


}
