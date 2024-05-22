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
        float sliderValue = _slider.value;
        float delay = 1f;

        for (float i = 0; i < delay; i += _recoveryRate * Time.deltaTime)
        {
            Debug.Log("sss");
            yield return null;

            _slider.value = Mathf.Lerp(sliderValue, health, i);
        }

        _slider.value = health;
    }
}
