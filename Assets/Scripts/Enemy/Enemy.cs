using UnityEngine;

[RequireComponent(typeof(PatrolBehaviour))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(IMover))]
public class Enemy : MonoBehaviour
{
    private PatrolBehaviour _patrol;
    private Flipper _flipper;
    private IMover _mover;   

    private void Awake()
    {
        _patrol = GetComponent<PatrolBehaviour>();
        _flipper = GetComponent<Flipper>();
        _mover = GetComponent<IMover>();        
    }

    private void Update()
    {
        _patrol.Work();

        _flipper.SetRotation(_mover.IsDirectionDefault);
    }
}
