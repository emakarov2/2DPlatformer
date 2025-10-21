using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private ManualCoin _manualCoinPrefab;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private float spawnChance = 0.7f;
   // [SerializeField] private float checkRadius = 1f;

    [SerializeField] private float interactiveCoinChance = 0.3f;

    private void Start()
    {
        StartCoroutine(SpawnCoinsRoutine());
    }

    private IEnumerator SpawnCoinsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (Random.value <= spawnChance)
            {
                SpawnCoin();
            }
        }
    }

    private void SpawnCoin()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned to CoinsSpawner!");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        var pointsList = spawnPoints.ToList();
        pointsList.RemoveAt(randomIndex);
        spawnPoints = pointsList.ToArray();

        if (Random.value <= interactiveCoinChance)
        {
            if (_manualCoinPrefab != null)
                Instantiate(_manualCoinPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            if (_coinPrefab != null)
                Instantiate(_coinPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}