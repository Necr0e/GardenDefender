using UnityEngine;
using TMPro;

namespace Global
{
    public class PlayerLives : MonoBehaviour
    {
        [SerializeField] private int lives = 5;
        private TextMeshProUGUI livesText;
        private LevelController levelController;

        private void Awake()
        {
            livesText = GetComponent<TextMeshProUGUI>();
            levelController = FindObjectOfType<LevelController>();
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
                levelController.HandleLoseCondition();
            }
        }
    }
}
