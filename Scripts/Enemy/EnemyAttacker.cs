using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _damage = 1;
    [SerializeField] private float _delay = 1;

    private bool _isRunner = false;
    private Coroutine _coroutine;
    private readonly int _attacked = Animator.StringToHash("Attacked");
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Health healthPlayer) && _damage > 0)
        { 
            _isRunner = true;
            _coroutine = StartCoroutine(WaitForDamage(healthPlayer));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Health player) && _damage > 0)
        {
            if(_coroutine != null)
            _isRunner = false;
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator WaitForDamage(Health healthPlayer)
    {
        var wait = new WaitForSeconds(_delay);

        while(_isRunner)
        {
            Attack(healthPlayer);
            yield return wait;
        }
    }

    private void Attack(Health player)
    {
        player.TakeDamage(_damage);
        _animator.SetTrigger(_attacked);
    }
}
