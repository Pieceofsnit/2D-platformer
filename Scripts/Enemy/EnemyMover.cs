using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;

    private Transform _currentTarget;
    private SpriteRenderer _spriteRenderer;
    private int _indexWaypoint = 0;
    private bool _isDiscovered;
    private float _minDistance = 0.5f;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentTarget = _waypoints[_indexWaypoint];
        _isDiscovered = false;
    }

    private void Update()
    {
        if (_isDiscovered)
        {
            Follow();
        }
        else
        {
            Patrol();
        }

        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isDiscovered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isDiscovered = false;
        }
    }

    private void Follow()
    {
        _currentTarget = _player;
        Flip();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentTarget.transform.position, _speed * Time.deltaTime);
    }

    private void Patrol()
    {
        _currentTarget = _waypoints[_indexWaypoint];

        if (CheckDistance())
        {
            SwitchNext();
            Flip(); 
        } 
    }

    private void SwitchNext()
    {
        _indexWaypoint++;

        if (_indexWaypoint == _waypoints.Count)
            _indexWaypoint = 0;

        _currentTarget = _waypoints[_indexWaypoint];
    }

    private bool CheckDistance()
    {
       return Vector2.Distance(transform.position, _currentTarget.position) < _minDistance;
    }

    private void Flip()
    {
        _spriteRenderer.flipX = transform.position.x > _currentTarget.position.x;
    }
}
