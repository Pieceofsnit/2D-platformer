using System.Collections;
using UnityEngine;

public class HealthPicker : MonoBehaviour
{
    [SerializeField] private Player _health;
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
        if (collision.TryGetComponent(out Enemy enemy))
        {
            if (_coroutine != null)
            {
                _isRunner = false;
                StopCoroutine(_coroutine);
            }
        }
    }

    private IEnumerator WaitForStealHealth(Enemy enemy)
    {
        
        var wait = new WaitForSeconds(_delay);
        _isRunner = false;

        for (int i = 0; i < _duration; i++)
        {
            StealHealth(enemy);
            yield return wait;
        }

        _isRunner = true;
    }

    private void SelectNearestTarget()
    {
        _collider = Physics2D.OverlapCircle(transform.position, _radius, _layerMaskEnemy);

        if (_collider.TryGetComponent(out Enemy enemy))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(WaitForStealHealth(enemy));
        }
    }

    private void StealHealth(Enemy enemy)
    {
        enemy.GetComponent<Health>().TakeDamage(_stolenHealth);
        _health.GetComponent<Health>().Restore(_stolenHealth);
    }
}
