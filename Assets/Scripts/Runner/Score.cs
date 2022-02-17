using UnityEngine;
using UnityEngine.UI;

namespace Runner
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private Transform _hero;
        
        //TODO: пока на трансформе завязано, в будущем может что поинтереснее будет
        private void Update()
        {
            _scoreText.text = ((int)_hero.position.z).ToString();
        }
    }
}