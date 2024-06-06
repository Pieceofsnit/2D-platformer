using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _checkGroundRadius;
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;
    private Vector2 _moveVector;
    private Quaternion _turnLeft = Quaternion.Euler(0f, 180f, 0f);
    private Quaternion _turnRight = Quaternion.identity;
    private readonly int _move = Animator.StringToHash("Speed");
    private readonly int _ground = Animator.StringToHash("IsGrounded");
    private string _horizontal = "Horizontal";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _checkGroundRadius = _groundCheck.GetComponent<CircleCollider2D>().radius;
    }   

    private void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Rotate(_moveVector.x);
        }
        
        Run();

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Run()
    {
        _moveVector.x = Input.GetAxis(_horizontal);
        _animator.SetFloat(_move, Mathf.Abs(_moveVector.x));
        _rigidbody.velocity = new Vector2(_moveVector.x * _speed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        _animator.SetTrigger(_ground);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _checkGroundRadius, _groundMask);
    }

    private void Rotate(float velocityX)
    {
        switch (velocityX)
        {
            case > 0:
                transform.localRotation = _turnRight;
                break;

            case < 0:
                transform.localRotation = _turnLeft;
                break;
        }
    }
}
