using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health: MonoBehaviour
{
    [SerializeField] private float _value;

    private float _maxValue;
    public float Value => _value;
    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        _maxValue = _value;
    }

    public void TakeDamage(float damage)
    {
        _value -= damage;
        CheckedLife();
        HealthChanged?.Invoke(_value);
    }

    public void Restore (float health)
    {
        _value += health;
        CheckedLife();
        HealthChanged?.Invoke(_value);
    }

    private void CheckedLife()
    {
        _value = Mathf.Clamp(_value, 0, _maxValue);
    }
}
