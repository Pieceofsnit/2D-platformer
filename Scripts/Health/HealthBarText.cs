using TMPro;
using UnityEngine;

public class HealthBarText : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _currentHealth;
    [SerializeField] private TextMeshProUGUI _maxHealth;

    private void Start()
    {
        _currentHealth.text = _health.Value.ToString();
        _maxHealth.text = _health.Value.ToString();
    }

    private void OnHealthChanged(float health)
    {
        _currentHealth.text = health.ToString();
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }
}
