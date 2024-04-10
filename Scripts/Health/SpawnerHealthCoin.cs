using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHealthCoin : MonoBehaviour
{
    [SerializeField] private List<HealthCoin> _healthCoins;
    [SerializeField] private List<Transform> _spawnPoints;

    private int _delay = 2;

    private void Start()
    {
        StartCoroutine(SpawnHealthCoins());
    }

    private IEnumerator SpawnHealthCoins()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        if(_healthCoins.Count <= _spawnPoints.Count)
        { 
            for (int i = 0; i < _healthCoins.Count; i++)
            {
                var spawnPoint = Random.Range(0, _spawnPoints.Count);
                Instantiate(_healthCoins[i], _spawnPoints[spawnPoint].transform.position, Quaternion.identity);
                _spawnPoints.RemoveAt(spawnPoint);
                yield return waitForSeconds;
            }
        }
    }
}
