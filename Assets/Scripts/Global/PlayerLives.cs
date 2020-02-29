using UnityEngine;
using TMPro;

namespace Global
{
    public class PlayerLives : MonoBehaviour
    {
        private readonly float baseLives = 10;
        private float lives;
        private TextMeshProUGUI livesText;
        private LevelController levelController;

        private void Awake()
        {
            livesText = GetComponent<TextMeshProUGUI>();
            levelController = FindObjectOfType<LevelController>();
        }
        //Lives: easy - 10, medium - 5, hard - 3
        private void Start()
        {
            lives = (Mathf.Floor(baseLives / PlayerPrefsController.GetDifficulty()));
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
