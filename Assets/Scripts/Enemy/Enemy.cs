using UnityEngine;

[RequireComponent(typeof(PatrolBehaviour))]
[RequireComponent(typeof(ChaseBehaviour))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(IMover))]
[RequireComponent(typeof(PlayerDetector))]
[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private PatrolBehaviour _patrol;
    private ChaseBehaviour _chase;
    private Flipper _flipper;
    private IMover _mover;
    private PlayerDetector _playerDetector;
    private Attacking _attacking;
    private Health _health;

    private void Awake()
    {
        _patrol = GetComponent<PatrolBehaviour>();
        _flipper = GetComponent<Flipper>();
        _mover = GetComponent<IMover>();
        _playerDetector = GetComponent<PlayerDetector>();
        _chase = GetComponent<ChaseBehaviour>();
        _attacking = GetComponent<Attacking>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (_playerDetector.CanAttack)
        {
            _attacking.StartAttack();
        }
        else if (_playerDetector.IsDetected)
        {
            _attacking.StopAttack();
            _chase.Work();
        }
        else
        {
            _attacking.StopAttack();
            _patrol.Work();
        }

        _flipper.SetRotation(_mover.IsDirectionDefault);
    }

    public void AcceptAttack(float damage)
    {
        _health.Decrease(damage);
    }
}