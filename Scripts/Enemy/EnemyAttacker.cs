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
        if(collision.collider.TryGetComponent<Player>(out Player player) && _damage > 0)
        { 
            _isRunner = true;
            _coroutine = StartCoroutine(WaitForDamage(player));
        }
    }

    private void Attack(Player player)
    {
        player.GetComponent<Health>().TakeDamage(_damage);
        _animator.SetTrigger(_attacked);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player) && _damage > 0)
        {
            if(_coroutine != null)
            _isRunner = false;
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator WaitForDamage(Player player)
    {
        var wait = new WaitForSeconds(_delay);

        while(_isRunner)
        {
            Attack(player);
            yield return wait;
        }
    }
}
