using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СollectingHealthСoins : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LifePoint>(out LifePoint lifePoint))
        {
            _health.Restore(lifePoint.HealthBonus);
            Destroy(lifePoint.gameObject);
        }
    }
}
