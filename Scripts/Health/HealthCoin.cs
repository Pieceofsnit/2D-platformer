using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCoin : MonoBehaviour
{
    private float _healthBonus = 1;
    public float HealthBonus => _healthBonus;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
        }
    }
}