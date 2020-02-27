using Enemy;
using UnityEngine;

namespace Global
{
    public class LevelController : MonoBehaviour
    {
        private int numberOfAttackers = 0;
        private bool levelTimerFinished = false;
        private EnemySpawner[] spawnerArray;
        private void Awake()
        {
            spawnerArray = FindObjectsOfType<EnemySpawner>();
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
                //Victory screen
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
