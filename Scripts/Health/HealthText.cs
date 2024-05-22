using TMPro;
using UnityEngine;

public class HealthText : HealthView
{   
    [SerializeField] private TextMeshProUGUI _currentHealth;
    [SerializeField] private TextMeshProUGUI _maxHealth;

    private void Start()
    {
        _currentHealth.text = Health.Value.ToString();
        _maxHealth.text = Health.Value.ToString();
    }

    protected override void OnHealthChanged(float health)
    {
        _currentHealth.text = health.ToString();
    }
}
