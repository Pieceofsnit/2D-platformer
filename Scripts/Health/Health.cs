using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health: MonoBehaviour
{
    [SerializeField] private float _health;

    private float _maxHealth;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        CheckedLife();
    }

    public void Restore (float health)
    {
        _health += health;
        CheckedLife();
    }

    private void CheckedLife()
    {
        _health = Mathf.Clamp(_health, 0, _maxHealth);
    }
}
