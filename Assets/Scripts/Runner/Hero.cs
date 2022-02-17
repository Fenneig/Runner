using System;
using Runner.Pause;
using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(CharacterController))]
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _swipeSpeed;
        [SerializeField] private float _gravityForce;
        [SerializeField] private float _lineDistance;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private GameObject _losePanel;

        private int _currentLine;
        private Vector3 _direction;

        private const float Tolerance = 0.01f;
        private const string Obstacle = "Obstacle";

        private void Awake()
        {
            GameStateManager.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnDestroy()
        {
            GameStateManager.OnGameStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState newGameState)
        {
            enabled = newGameState == GameState.Gameplay;
        }

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
            if (isRight && _currentLine < 1)
            {
                _currentLine++;
            }
            if (!isRight && _currentLine > -1)
            {
                _currentLine--;
            }
        }

        private void Update()
        {
            var targetPosition = Vector3.up * transform.position.y + Vector3.forward * transform.position.z;
            targetPosition += new Vector3(_currentLine, 0, 0) * _lineDistance;

            if (Math.Abs(transform.position.x - targetPosition.x) < Tolerance) return;

            var positionDifference = targetPosition - transform.position;
            var moveDirection = positionDifference * _swipeSpeed * Time.deltaTime;
            var target = moveDirection.sqrMagnitude < positionDifference.sqrMagnitude
                ? moveDirection
                : positionDifference;
            _controller.Move(target);
        }

        private void Jump()
        {
            if (_controller.isGrounded) _direction.y = _jumpSpeed;
        }

        private void Slide()
        {
        }

        private void FixedUpdate()
        {
            _direction.z = _speed;
            _direction.y += _gravityForce * Time.fixedDeltaTime;
            _controller.Move(_direction * Time.fixedDeltaTime);
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (!hit.gameObject.CompareTag(Obstacle)) return;
            _losePanel.SetActive(true);
            GameStateManager.SetState(GameState.End);
        }
    }
}