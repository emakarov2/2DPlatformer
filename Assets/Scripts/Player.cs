using UnityEngine;

[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(Collector))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private string _isGrounded = "IsGrounded";
    [SerializeField] private string _verticalSpeed = "VerticalSpeed";
    [SerializeField] protected string _isRunning = "IsRunning";

    private int _isGroundedHash;
    private int _verticalSpeedHash;
    private int _isRunningHash;

    private Flipper _flipper;
    private InputReader _inputReader;
    private PlayerMover _mover;
    private GroundDetector _groundDetector;
    private Collector _collector;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _flipper = GetComponent<Flipper>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<PlayerMover>();
        _groundDetector = GetComponent<GroundDetector>();
        _collector = GetComponent<Collector>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _isGroundedHash = Animator.StringToHash(_isGrounded);
        _verticalSpeedHash = Animator.StringToHash(_verticalSpeed);
        _isRunningHash = Animator.StringToHash(_isRunning);
    }

    void Update()
    {
        _flipper.SetRotation(_inputReader.IsDirectionDefault);
        
        SetupAnimator();
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        { 
            _mover.HorizontalMove(_inputReader.Direction); 
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGrounded)
        { 
            _mover.Jump(); 
        }

        if (_inputReader.GetIsInteracting())
        {
            _collector.CollectBerry();
        }
    }

    private void SetupAnimator()
    {
        bool isMoving = _inputReader.Direction != 0;

        _animator.SetBool(_isGroundedHash, _groundDetector.IsGrounded);
        _animator.SetBool(_isRunningHash, isMoving);
        _animator.SetFloat(_verticalSpeedHash, _rigidbody.velocity.y);
    }
}