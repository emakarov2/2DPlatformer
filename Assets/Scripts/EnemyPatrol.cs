using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    private EnemyMover _mover;

    private int _pointIndex = 0;
    private float _distanceInaccuracy = 1.5f;
    private float _delayAtBorder = 3f;
    private bool _isWaiting = false;


    private void Start()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        if (_isWaiting) return;

        Transform _pointByIndex = _wayPoints[_pointIndex];

        _mover.MoveToTarget(_pointByIndex.position);

        if (Vector2.Distance(transform.position, _pointByIndex.position) < _distanceInaccuracy)        
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    private IEnumerator WaitAtPoint()
    {
        WaitForSeconds delay = new WaitForSeconds(_delayAtBorder);
        
        _isWaiting = true;
        
        _mover.Stop();

        yield return delay;

        SetNextWayPoint();

        _mover.Continue();

        _isWaiting = false;
    }

    private void SetNextWayPoint()
    {
        _pointIndex = ++_pointIndex % _wayPoints.Length;
    }
}
