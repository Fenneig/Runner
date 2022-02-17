using Runner.Pause;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class LevelLoader : MonoBehaviour
    {
        public void LoadLevel(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            GameStateManager.SetState(GameState.Gameplay);
        }
    }
}