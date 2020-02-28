using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    public class LevelLoader : MonoBehaviour
    {
        private int currentSceneIndex;
        private void Awake()
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
        public void StartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }
        public void LoadNextScene()
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        public void LoadMainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
