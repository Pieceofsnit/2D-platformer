using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected abstract void OnHealthChanged(float health);
}
