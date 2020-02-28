using System.Collections;
using Enemy;
using UnityEngine;

namespace Global
{
    public class LevelController : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] 
        private GameObject winLabel;
        [SerializeField]
        private GameObject loseLabel;
#pragma warning restore 0649
        private EnemySpawner[] spawnerArray;
        private AudioSource audioSource;
        private LevelLoader levelLoader;
        private int numberOfAttackers;
        private bool levelTimerFinished;
        private const float WaitToLoad = 4f;
        private void Awake()
        {
            spawnerArray = FindObjectsOfType<EnemySpawner>();
            audioSource = GetComponent<AudioSource>();
            levelLoader = GetComponent<LevelLoader>();
        }
        private void Start()
        {
            winLabel.SetActive(false);
            loseLabel.SetActive(false);
        }
        IEnumerator HandleWinCondition()
        {
            winLabel.SetActive(true);
            audioSource.Play();
            yield return new WaitForSeconds(WaitToLoad);
            levelLoader.LoadNextScene();
        }
        public void HandleLoseCondition()
        {
            loseLabel.SetActive(true);
            Time.timeScale = 0;
        }
        public void AttackerSpawned()
        {
            numberOfAttackers++;
        }
        public void AttackedKilled()
        {
            numberOfAttackers--;
            if (numberOfAttackers <= 0 && levelTimerFinished)
            {
                StartCoroutine(HandleWinCondition());
            }
        }
        public void LevelTimerFinished()
        {
            levelTimerFinished = true;
            StopSpawners();
        }
        private void StopSpawners()
        {
            foreach (EnemySpawner spawner in spawnerArray)
            {
                spawner.StopSpawning();
            }
        }
    }
}
