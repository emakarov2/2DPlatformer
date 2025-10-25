using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(InputReader))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private string _isGrounded = "IsGrounded";
    [SerializeField] private string _verticalSpeed = "VerticalSpeed";
    [SerializeField] protected string _isRunning = "IsRunning";

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private GroundDetector _groundDetector;
    private InputReader _inputReader;

    private int _isGroundedHash;
    private int _verticalSpeedHash;
    private int _isRunningHash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
    }

    private void Start()
    {
        _isGroundedHash = Animator.StringToHash(_isGrounded);
        _verticalSpeedHash = Animator.StringToHash(_verticalSpeed);
        _isRunningHash = Animator.StringToHash(_isRunning);
    }

    private void Update()
    {     
        SetupAnimator();
    }

    private void SetupAnimator()
    {
        bool isMoving = _inputReader.Direction != 0;

        _animator.SetBool(_isGroundedHash, _groundDetector.IsGrounded);
        _animator.SetBool(_isRunningHash, isMoving);
        _animator.SetFloat(_verticalSpeedHash, _rigidbody.velocity.y);
    }
}
