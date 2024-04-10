using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _range;
    [SerializeField] private float _damage;
    [SerializeField] private float _startTimeCounter = 1f;
    [SerializeField] private Animator _animator;

    private readonly int _attack = Animator.StringToHash("Attack");
    private float _timeCounter;

    private void Start()
    {
        _timeCounter = _startTimeCounter;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && _timeCounter <= 0)
        {
            Attack();
            _animator.SetTrigger(_attack);
            _timeCounter = _startTimeCounter;
        }

        if (_timeCounter > 0)
        {
            _timeCounter -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _range,_enemyLayer);

        foreach(Collider2D enemy in enemies)
        {
            if ((enemy.TryGetComponent(out Health enemyHealth)))
            {
                enemyHealth.TakeDamage(_damage);
            }
        }
    }
}
