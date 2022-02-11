using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lineDistance;
    [SerializeField] private CharacterController _controller;

    private int _currentLine;
    private Vector3 _direction;

    public void Move(Vector2 swipeDirection)
    {
        if (swipeDirection.x != 0)
        {
            SwipeLine(swipeDirection.x > 0);
        }

        if (swipeDirection.y != 0)
        {
            if (swipeDirection.y > 0) Jump();
            else Slide();
        }
    }

    private void SwipeLine(bool isRight)
    {
        var isMoved = false;
        if (isRight && _currentLine < 1)
        {
            _currentLine++;
            isMoved = true;
        }

        if (!isRight && _currentLine > -1)
        {
            _currentLine--;
            isMoved = true;
        }

        if (!isMoved) return;

        var moveTarget = isRight ? Vector3.right * _lineDistance : Vector3.left * _lineDistance;
        _controller.Move(moveTarget);
    }

    private void Jump()
    {
    }

    private void Slide()
    {
    }

    private void FixedUpdate()
    {
        _direction.z = _speed;

        _controller.Move(_direction * Time.fixedDeltaTime);
    }
}