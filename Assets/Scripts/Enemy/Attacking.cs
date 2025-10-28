using System.Collections;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private float _damage = 5f;
    [SerializeField] private float _delay = 1f;

    private Coroutine _coroutine;

    public void StartAttack()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(StrikePerDelayRoutine());
        }
    }

    public void StopAttack()
    {
        if (_coroutine != null)
        {
            StopCoroutine( _coroutine );
            _coroutine = null;
        }
    }

    private IEnumerator StrikePerDelayRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;
            Strike();
        }
    }

    private void Strike()
    {
        _player.AcceptAttack(_damage);
    }
}