using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;
 
    protected void OnEnable()
    {
        Health.HealthChanged += OnHealthChanged;
    }

    protected void OnDisable()
    {
        Health.HealthChanged -= OnHealthChanged;
    }

    protected abstract void OnHealthChanged(float health);
}
