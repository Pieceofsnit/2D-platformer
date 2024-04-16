using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _range;
    [SerializeField] private float _damage;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private Animator _animator;

    private readonly int _attack = Animator.StringToHash("Attack");
    private Coroutine _coroutine;
    private float _timeAttack;
    private bool _isRunner = true;

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && _isRunner == true)
        {
            if(_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(WaitForDamage());
            _animator.SetTrigger(_attack);
        }
    }

    public void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _range,_enemyLayer);

        foreach(Collider2D enemy in enemies)
        {
            if (enemy.TryGetComponent(out Health enemyHealth))
            {
                enemyHealth.TakeDamage(_damage);
            }
        }
    }

    private IEnumerator WaitForDamage()
    {
        _isRunner = false;
        yield return new WaitForSeconds(_delay);
        _isRunner = true;
        Attack();
        Debug.Log("Attack");  
    }
}
