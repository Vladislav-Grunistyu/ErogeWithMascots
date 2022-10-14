using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _offset = 5;

    private Animator _animator;
    private Transform _target;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private int _isMovable;

    private void Start()
    {
        _target = FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveToTarget(_speed,_target);
    }
    private void Update()
    {
        _direction = _target.position - transform.position;
        _direction.Normalize();
        SetAnimationState();
    }

    private void MoveToTarget(float speed, Transform target)
    {
        if (Vector2.Distance(transform.position, target.position) > _offset)
        {
            _rigidbody2D.MovePosition((Vector2)transform.position + (_direction * _speed * Time.deltaTime));
            _isMovable = 1;
        }
        else
        {
            _isMovable = 0;
        }
    }
    private void SetAnimationState()
    {
        _animator.SetFloat("Horizontal", _direction.x);
        _animator.SetFloat("Vertical", _direction.y);
        _animator.SetFloat("Speed", _isMovable);
    }
}
