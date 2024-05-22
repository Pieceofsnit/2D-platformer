using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLifePoint : MonoBehaviour
{
    [SerializeField] private List<LifePoint> _lifePoints;
    [SerializeField] private List<Transform> _spawnPoints;

    private int _delay = 2;

    private void Start()
    {
        StartCoroutine(SpawnHealthCoins());
    }

    private IEnumerator SpawnHealthCoins()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        if(_lifePoints.Count <= _spawnPoints.Count)
        { 
            for (int i = 0; i < _lifePoints.Count; i++)
            {
                var spawnPoint = Random.Range(0, _spawnPoints.Count);
                Instantiate(_lifePoints[i], _spawnPoints[spawnPoint].transform.position, Quaternion.identity);
                _spawnPoints.RemoveAt(spawnPoint);
                yield return waitForSeconds;
            }
        }
    }
}
