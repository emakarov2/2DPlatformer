using System;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action<Coin> CollectedItem;

    private List<Berry> _berriesNear = new List<Berry>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Gem gem))
        {
            CollectedItem?.Invoke(gem);
        }

        if (collision.gameObject.TryGetComponent<Berry>(out Berry berry))
        {
            if (_berriesNear.Contains(berry) == false)
            {
                _berriesNear.Add(berry);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Berry>(out Berry berry))
        {
            _berriesNear.Remove(berry);
        }
    }

    public void CollectBerry()
    {
        if (_berriesNear.Count > 0)
        {
            Berry berry = _berriesNear[0];
            CollectedItem?.Invoke(berry);
        }
    }
}