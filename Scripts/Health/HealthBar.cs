using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _recoveryRate;

    private Coroutine _changeBar;
    private float _healthBar;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    public void Start()
    {
        _slider.maxValue = _health.Value;
        _slider.value = _health.Value;
        _healthBar = _health.Value;
    }

    private void OnHealthChanged(float health)
    {
        _changeBar = StartCoroutine(ChangeHealthBar(health));
    }

    private IEnumerator ChangeHealthBar(float health)
    {
        _healthBar = health;
        while (_healthBar != _slider.value)
        {
            Debug.Log("Жизни " + _healthBar);
            _slider.value = Mathf.MoveTowards(_slider.value, _healthBar, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}
