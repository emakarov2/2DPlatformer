using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundDetector))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 7f;

    private Rigidbody2D _rigidbody;

    private GroundDetector _groundDetector;

    private float _moveInput;

    private bool _isGrounded;

    public event Action<float> MoveInputChanged;

    public float MoveInput => _moveInput;

    public bool IsGrounded => _groundDetector.IsGrounded;

    public Rigidbody2D Rigidbody => _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundDetector = GetComponent<GroundDetector>();
        _groundDetector.GroungingChandeg += OnGroundingChanged;
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        HorizontalMove();
    }

    private void HandleInput()
    {
        float previousMoveInput = _moveInput;
        float currentMoveInput = Input.GetAxisRaw(Horizontal);

        if (Mathf.Abs(currentMoveInput - previousMoveInput) > 0.01f)
        {
            _moveInput = currentMoveInput;
            MoveInputChanged?.Invoke(currentMoveInput);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private void OnGroundingChanged(bool isGrounded)
    {
        _isGrounded = isGrounded;
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