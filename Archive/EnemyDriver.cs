using UnityEngine;

[RequireComponent(typeof(EnemyBorderDetector))]
[RequireComponent(typeof(EnemyMover))]
public class EnemyDriver : MonoBehaviour
{
    private EnemyBorderDetector _borderDetector;
    private EnemyMover _mover;

    private void OnEnable()
    {

    }

    private  void Start()
    {
        _borderDetector = GetComponent<EnemyBorderDetector>();
        _mover = GetComponent<EnemyMover>();
        _borderDetector.BorderReached += OnBorderReached;
    }

    private void Update()
    {
        
    }

    private void OnDisable()
    {
        _borderDetector.BorderReached -= OnBorderReached;
    }

    private void OnBorderReached()
    {
        _mover.Reverse();
    }
}
