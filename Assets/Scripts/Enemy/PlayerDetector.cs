using System.Collections;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _sightDistance = 100f;
    [SerializeField] private float _sightAngle = 120f;
    [SerializeField] private LayerMask _obstacleLayer;
    [SerializeField] Transform _player;

    private Vector2 _directionToPlayer;

    private float _attackDistance = 2f;

    public bool IsDetected { get; private set; }
    public bool CanAttack { get; private set; }

    private void Start()
    {
        _directionToPlayer = _player.position - transform.position;
        StartCoroutine(PlayerCheckRoutine());
    }

    private bool CanSeePlayer()
    {
        if (_player == null) return false;

        _directionToPlayer = _player.position - transform.position;
        float distanceToPlayer = _directionToPlayer.magnitude;
        float sightAngleHalf = _sightAngle / 2;

        if (_directionToPlayer.sqrMagnitude > _sightDistance * _sightDistance) return false;

        float angleToPlayer = Vector2.Angle(transform.right, _directionToPlayer);
        if (angleToPlayer > sightAngleHalf) return false;

        RaycastHit2D hit = Physics2D.Raycast(
         transform.position,
         _directionToPlayer.normalized,
         distanceToPlayer,
         _obstacleLayer
                       );

        return hit.collider == null;
    }

    private bool IsPlayerInAttackSector()
    {
        return (IsDetected && _directionToPlayer.sqrMagnitude <= _attackDistance * _attackDistance);
    }

    private IEnumerator PlayerCheckRoutine() 
    {
        float delay = 0.1f;
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return waitForSeconds;
            IsDetected = CanSeePlayer();
            CanAttack = IsPlayerInAttackSector();
        }
    }
}