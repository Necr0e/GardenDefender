using Enemy;
using UnityEngine;

namespace Defenders
{
    public class Shooter : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private GameObject projectile, launchLocation;
        private EnemySpawner myLaneSpawner;
        private Animator animator;
        private static readonly int IsAttacking = Animator.StringToHash("isAttacking");
#pragma warning restore 0649

        private void Start()
        {
            animator = GetComponent<Animator>();
            SetLaneSpawner();
        }
        private void Update()
        {
            animator.SetBool(IsAttacking, IsAttackerInLane());
        }

        private void SetLaneSpawner()
        {
            var spawners = FindObjectsOfType<EnemySpawner>();
            foreach(EnemySpawner spawner in spawners)
            {
                bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
                if (isCloseEnough)
                {
                    myLaneSpawner = spawner;
                }
            }
        }
        private bool IsAttackerInLane()
        {
            return myLaneSpawner.transform.childCount > 0;
        }
        
        public void Fire()
        {
            Instantiate(projectile, launchLocation.transform.position, transform.rotation);
        }
    }
}
