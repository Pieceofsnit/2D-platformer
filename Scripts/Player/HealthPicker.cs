using System;
using System.Collections;
using UnityEngine;

public class HealthPicker : MonoBehaviour
{
    [SerializeField] private Health _healthPlayer;
    [SerializeField] private LayerMask _layerMaskEnemy;
    [SerializeField] private KeyCode _stealHealth;

    private Collider2D _collider;
    private Coroutine _coroutine;
    private bool _isRunner = true;
    private float _delay = 1;
    private float _duration = 6;
    private float _stolenHealth = 1;
    private float _radius = 2;

    private void Update()
    {
        Debug.Log(_isRunner);
        if (Input.GetKey(_stealHealth) && _isRunner == true)
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
                if(enemyHealth != null)
                StealHealth(enemyHealth);
                yield return wait;
            }

            _isRunner = true;
    }

    private void SelectNearestTarget()
    {
        _collider = Physics2D.OverlapCircle(transform.position, _radius, _layerMaskEnemy);
        Debug.Log(_collider.TryGetComponent(out Health aaa));
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
