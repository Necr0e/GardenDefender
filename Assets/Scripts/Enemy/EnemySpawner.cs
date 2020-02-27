using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private bool isSpawning = true;
#pragma warning disable 0649
        [SerializeField] private Attacker[] attackerPrefabs;
        [SerializeField] private float maxSpawnDelay = 1f;
        [SerializeField] private float maxSpawnTime = 6f;
#pragma warning restore 0649

        public void StopSpawning()
        {
            isSpawning = false;
        }
        private void Start()
        {
            StartCoroutine(StartEnemySpawning());
        }
        private IEnumerator StartEnemySpawning()
        {
            while (isSpawning)
            {
                yield return new WaitForSeconds(Random.Range(maxSpawnDelay, maxSpawnTime));
                SpawnAttacker();
            }
        }
        private void SpawnAttacker()
        {
            int attackerIndex = Random.Range(0, attackerPrefabs.Length);
            Spawn(attackerPrefabs[attackerIndex]);
        }

        private void Spawn(Attacker myAttacker)
        {
            Attacker newAttacker = Instantiate(myAttacker, transform.position, Quaternion.identity);
            newAttacker.transform.parent = transform;
        }
    }
}
