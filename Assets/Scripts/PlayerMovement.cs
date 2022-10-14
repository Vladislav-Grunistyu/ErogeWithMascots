using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]  private float _speed = 1;

    private Rigidbody2D _rb;
    private Animator _animator;
    Vector2 _movement;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        InputMovement();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void InputMovement()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        SetAnimationState();
    }

    private void Movement()
    {
        _rb.MovePosition(_rb.position + _movement * _speed * Time.deltaTime);
    }

    private void SetAnimationState()
    {
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);
    }
}
