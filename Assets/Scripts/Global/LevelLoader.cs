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
            SceneManager.LoadScene(1);
        }
        
        public void LoadNextScene()
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        public static void LoadGameOverScene()
        {
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        }
        public void LoadCreditsScene()
        {
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
