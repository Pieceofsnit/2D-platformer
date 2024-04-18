using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public  class HealthBarSlider : HealthBar
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _recoveryRate;

    private Coroutine _changeBar;

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
    }

    protected override void  OnHealthChanged(float health)
    {
        if(_changeBar != null)
        {
            StopCoroutine(_changeBar);
        }

        _changeBar = StartCoroutine(ChangingHealthBar(health));
    }

    private IEnumerator ChangingHealthBar(float health)
    {
        while (health != _slider.value)
        {
            Debug.Log("Жизни " + health);
            _slider.value = Mathf.MoveTowards(_slider.value, health, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}
