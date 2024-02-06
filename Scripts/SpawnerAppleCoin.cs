using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAppleCoin : MonoBehaviour
{
    [SerializeField] private List<AppleCoin> _appleCoins;
    [SerializeField] private List<Transform> _spawnPoints;

    private int _delay = 2;

    private void Start()
    {
        StartCoroutine(SpawnAppleCoins());
    }

    private IEnumerator SpawnAppleCoins()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        if(_appleCoins.Count <= _spawnPoints.Count)
        { 
            for (int i = 0; i < _appleCoins.Count; i++)
            {
                var spawnPoint = Random.Range(0, _spawnPoints.Count);
                Instantiate(_appleCoins[i], _spawnPoints[spawnPoint].transform.position, Quaternion.identity);
                _spawnPoints.RemoveAt(spawnPoint);
                yield return waitForSeconds;
            }
        }
    }
}
