using UnityEngine;

public class PlayerAnimator : BaseAnimator
{
    [SerializeField] private string _isGrounded = "IsGrounded";
    [SerializeField] private string _verticalSpeed = "VerticalSpeed";

    private PlayerMover _playerMover;
    private GroundDetector _groundDetector;

    private bool _cachedIsGrounded;
    private bool _cachedIsRunning;
    private float _cachedMoveInput;

    protected override void Start()
    {
        base.Start();
        _playerMover = GetComponent<PlayerMover>();
        _groundDetector = GetComponent<GroundDetector>();

        _playerMover.MoveInputChanged += OnMoveInputChanged;
        _groundDetector.GroungingChandeg += OnGroundingChanged;
    }

    protected override void UpdateAnimations()
    {
        _animator.SetBool(_isRunning, _cachedIsRunning);
        _animator.SetBool(_isGrounded, _cachedIsGrounded);
        _animator.SetFloat(_verticalSpeed, _playerMover.Rigidbody.velocity.y);
    }

    protected override float GetMovementDirection()
    {
        return _cachedMoveInput;
    }

    private void OnGroundingChanged(bool isGrounded)
    {
        if (_cachedIsGrounded != isGrounded)
        {
            _cachedIsGrounded = isGrounded;
        }
    }

    private void OnMoveInputChanged(float moveInput)
    {
        _cachedMoveInput = moveInput;
        _cachedIsRunning = Mathf.Abs(moveInput) > 0.01f;
    }

    private void OnDisable()
    {
        _playerMover.MoveInputChanged -= OnMoveInputChanged;
        _groundDetector.GroungingChandeg -= OnGroundingChanged;
    }
}