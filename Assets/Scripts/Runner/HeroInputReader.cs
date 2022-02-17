using Runner.Pause;
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

        //можно менять состояние с геймплейя на паузу и обратно, нельзя снять с паузы игру, если она проиграна (состояние end)
        public void OnPause(InputAction.CallbackContext context)
        {
            var currentGameState = GameStateManager.CurrentGameState;
            if (currentGameState == GameState.End) return;
            var newGameState = currentGameState == GameState.Gameplay ? GameState.Pause : GameState.Gameplay;
            GameStateManager.SetState(newGameState);
        }
    }
}