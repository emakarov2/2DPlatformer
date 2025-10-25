using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] protected string _isRunning = "IsRunning";

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private int _isRunningHash;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _isRunningHash = Animator.StringToHash(_isRunning);
    }

    private void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        float minSpeed = 0.1f;

        bool isMoving = Mathf.Abs(_rigidbody.velocity.x) > minSpeed;
        _animator.SetBool(_isRunningHash, isMoving);
    }
}