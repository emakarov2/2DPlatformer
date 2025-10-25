using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Collector _collector;

    [SerializeField] private Gem _gemPrefab;
    [SerializeField] private Berry _berryPrefab;
    
    [SerializeField] private List <Transform> _spawnPoints;

    [SerializeField] private float _spawnInterval = 4f;
    [SerializeField] private float _spawnChance = 0.7f;

    [SerializeField] private float _interactiveCoinChance = 0.3f;

    private void Start()
    {
        StartCoroutine(SpawnCoinsRoutine());

        _collector.CollectedItem += OnCollectedItem;
    }

    private void OnDisable()
    {
        _collector.CollectedItem -= OnCollectedItem;
    }

    private IEnumerator SpawnCoinsRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnInterval);

        while (enabled)
        {
            yield return delay;

            if (Random.value <= _spawnChance)
            {
                SpawnCoin();
            }
        }
    }

    private void OnCollectedItem(Coin coin)
    {     
        Destroy(coin.gameObject);
    }

    private void SpawnCoin()
    {
        if (_spawnPoints.Count == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, _spawnPoints.Count);
        Transform spawnPoint = _spawnPoints[randomIndex];
                
        _spawnPoints.RemoveAt(randomIndex);
        
        if (Random.value <= _interactiveCoinChance)
        {
            if (_berryPrefab != null)
            {
                Instantiate(_berryPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
        else
        {
            if (_gemPrefab != null)
            {
                Instantiate(_gemPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}