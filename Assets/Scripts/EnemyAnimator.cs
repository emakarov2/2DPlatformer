using UnityEngine;

public class EnemyAnimator : BaseAnimator
{
    protected override void UpdateAnimations()
    {
        bool isMoving = Mathf.Abs(_rigidbody.velocity.x) > 0;
        _animator.SetBool(_isRunning, isMoving);
    }

    protected override float GetMovementDirection()
    {
        return _rigidbody.velocity.x;
    }
}