using System;

namespace Runner.Pause
{
    public static class GameStateManager
    {
        public static GameState CurrentGameState { get; set; }

        public static Action<GameState> OnGameStateChanged;

        public static void SetState(GameState newGameState)
        {
            if (newGameState == CurrentGameState) return;

            CurrentGameState = newGameState;
            OnGameStateChanged?.Invoke(newGameState);
        }
    }
}