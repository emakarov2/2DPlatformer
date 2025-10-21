using System;
using UnityEngine;

public class EnemyBorderDetector : MonoBehaviour
{
    [SerializeField] private float _distance = 6f;

    private Vector2 _startPosition;

    private bool _wasBorderReached = false;

    public event Action BorderReached;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        float currentX = transform.position.x;

        bool isBorderReached = currentX >= _startPosition.x + _distance ||
            currentX <= _startPosition.x - _distance;

        if (isBorderReached && _wasBorderReached == false)
        {
            BorderReached?.Invoke();

            _wasBorderReached = true;
        }

        if (isBorderReached == false && _wasBorderReached)
        {
            _wasBorderReached = false;
        }
    }
}
