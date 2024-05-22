using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public  class HealthBarSlider : HealthView
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _recoveryRate;

    private Coroutine _changeBar;

    public void Start()
    {
        _slider.maxValue = Health.Value;
        _slider.value = Health.Value;
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
        float value = _slider.value;

        while (Health.Value != value)
        {
            value = Mathf.Lerp(value, health, _recoveryRate * Time.deltaTime);
            _slider.value = value;
            yield return null;
        }
    }
}
