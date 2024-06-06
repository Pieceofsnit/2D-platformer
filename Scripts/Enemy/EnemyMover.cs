using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;

    private Quaternion _turnLeft = Quaternion.Euler(0f, 180f, 0f);
    private Quaternion _turnRight = Quaternion.identity;
    private Transform _currentTarget;
    private int _indexWaypoint = 0;
    private bool _isDiscovered;
    private bool _isRotate;
    private float _minDistance = 0.5f;

    private void Start()
    {
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
        if (collision.TryGetComponent(out Player player))
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
        Rotate();
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
        } 
        
        Rotate();
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

    private void Rotate()
    {
        _isRotate = transform.position.x < _currentTarget.position.x;

        if (_isRotate)
            transform.localRotation = _turnRight;
        else
            transform.localRotation = _turnLeft;   
    }
}
