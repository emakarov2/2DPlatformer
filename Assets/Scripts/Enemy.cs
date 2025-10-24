using UnityEngine;

[RequireComponent(typeof(PatrolBehaviour))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(IMover))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] protected string _isRunning = "IsRunning";

    private PatrolBehaviour _patrol;
    private Flipper _flipper;
    private IMover _mover;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private int _isRunningHash;

    void Start()
    {
        _patrol = GetComponent<PatrolBehaviour>();
        _flipper = GetComponent<Flipper>();
        _mover = GetComponent<IMover>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _isRunningHash = Animator.StringToHash(_isRunning);
    }

    void Update()
    {
        _patrol.Work();

        _flipper.SetRotation(_mover.IsDirectionDefault);

        UpdateAnimations();
    }

    public void SetOrientation(bool isOrientDefault)
    {
        _flipper.SetRotation(isOrientDefault);
    }

    protected virtual void UpdateAnimations()
    {
        float minSpeed = 0.1f;

        bool isMoving = Mathf.Abs(_rigidbody.velocity.x) > minSpeed;
        _animator.SetBool(_isRunningHash, isMoving);
    }
}
