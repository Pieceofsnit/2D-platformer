using System.Collections;
using UnityEngine;

public class HealthPicker : MonoBehaviour
{
    [SerializeField] private Health _healthPlayer;
    [SerializeField] private LayerMask _layerMaskEnemy;

    private Collider2D _collider;
    private Coroutine _coroutine;
    private bool _isRunner = true;
    private float _delay = 1;
    private float _duration = 6;
    private float _stolenHealth = 1;
    private float _radius = 2;

    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && _isRunner == true)
        {
            SelectNearestTarget();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health enemyHealth))
        {
            if (_coroutine != null)
            {
                _isRunner = false;
                StopCoroutine(_coroutine);
            }
        }
    }

    private IEnumerator WaitForStealHealth(Health enemyHealth)
    {
        var wait = new WaitForSeconds(_delay);
        _isRunner = false;

        for (int i = 0; i < _duration; i++)
        {
            StealHealth(enemyHealth);
            yield return wait;
        }

        _isRunner = true;
    }

    private void SelectNearestTarget()
    {
        _collider = Physics2D.OverlapCircle(transform.position, _radius, _layerMaskEnemy);

        if (_collider.TryGetComponent(out Health enemyHealth))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(WaitForStealHealth(enemyHealth));
        }
    }

    private void StealHealth(Health enemyHealth)
    {
        enemyHealth.TakeDamage(_stolenHealth);
        _healthPlayer.Restore(_stolenHealth);
    }
}
