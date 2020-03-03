using Enemy;
using UnityEngine;

namespace Defenders
{
    public class Shooter : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private GameObject projectile, launchLocation;
#pragma warning restore 0649
        private EnemySpawner myLaneSpawner;
        private Animator animator;
        private GameObject projectileParent;
        private const string ProjectileParentName = "Projectiles";
        private static readonly int IsAttacking = Animator.StringToHash("isAttacking");

        private void Awake()
        {
            animator = GetComponent<Animator>();
            projectileParent = GameObject.Find(ProjectileParentName);
        }
        private void Start()
        {
            CreateProjectileParent();
            SetLaneSpawner();
        }
        private void Update()
        {
            animator.SetBool(IsAttacking, IsAttackerInLane());
        }
        
        private void CreateProjectileParent()
        {
            if (!projectileParent)
            {
                projectileParent = new GameObject(ProjectileParentName);
            }
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
            GameObject newProjectile = Instantiate(projectile, launchLocation.transform.position, transform.rotation);
            newProjectile.transform.parent = projectileParent.transform;
        }
    }
}
