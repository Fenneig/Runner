using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;

    private Vector3 _direction;

    private void Awake()
    {
        _direction = new Vector3(0, 0, _speed);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = new Vector3(direction.x, direction.y, _speed);
    }

    private void FixedUpdate()
    {
        _controller.Move(_direction * _speed * Time.deltaTime);
    }
}