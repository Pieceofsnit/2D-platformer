using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СollectingHealthСoins : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HealthCoin>(out HealthCoin health))
        {
            _health.Restore(health.HealthBonus);
        }
    }
}
