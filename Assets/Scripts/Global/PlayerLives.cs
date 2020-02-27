using UnityEngine;
using TMPro;

namespace Global
{
    public class PlayerLives : MonoBehaviour
    {
        [SerializeField] private int lives = 5;
        private TextMeshProUGUI livesText;

        private void Awake()
        {
            livesText = GetComponent<TextMeshProUGUI>();
        }
        private void Start()
        {
            UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            livesText.text = lives.ToString();
        }
        public void TakeLife()
        {
            lives -= 1;
            UpdateDisplay();
            if (lives <= 0)
            {
                LevelLoader.LoadGameOverScene();
            }
        }
    }
}
