using UnityEngine;
using UnityEngine.InputSystem;

namespace Runner
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        public void OnMovement(InputAction.CallbackContext context)
        {
            if (context.started) _hero.Move(context.ReadValue<Vector2>());
        }
    }
}