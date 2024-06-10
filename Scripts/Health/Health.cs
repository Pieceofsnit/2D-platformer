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
        ChangeHealth(- damage);
    }

    public void Restore (float health)
    {
        ChangeHealth(health);
    }

    private void ChangeHealth(float value)
    {
        _value = Mathf.Clamp(_value += value, 0, _maxValue);
        HealthChanged?.Invoke(_value);

        if(_value <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
