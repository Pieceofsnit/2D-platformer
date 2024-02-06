using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _turningPointA;
    [SerializeField] private Transform _turningPointB;
    [SerializeField] private float _speed;

    private Vector2 _moveVector;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private int _direction = 1;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _moveVector.x = _direction;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {

        if (_turningPointA.position.x >= transform.position.x)
        {
            _moveVector.x = _direction;
            Flip();
        }
        else if (_turningPointB.position.x <= transform.position.x)
        {
            _moveVector.x = -_direction;
            Flip();
        }

        _rigidbody.velocity = new Vector2(_moveVector.x * _speed, _rigidbody.velocity.y);
    }

    private void Flip()
    {
        _spriteRenderer.flipX = _moveVector.x < 0;
    }
}
