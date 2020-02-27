using System;
using Global;
using UnityEngine;

namespace Enemy
{
    public class Attacker : MonoBehaviour
    {
        [Header("Assignments")] 
        [SerializeField] [Range(0f, 5f)] private float currentSpeed = 2f;

        private GameObject currentTarget;
        private Animator animator;
        private LevelController levelController;
        private static readonly int IsAttacking = Animator.StringToHash("isAttacking");

        private void Awake()
        {
            animator = GetComponent<Animator>();
            levelController = FindObjectOfType<LevelController>();
            levelController.AttackerSpawned();
            
        }
        private void Update()
        {
            MoveForward();
            UpdateAnimationState();
        }

        private void OnDestroy()
        {
            levelController.AttackedKilled();
        }

        private void MoveForward()
        {
            transform.Translate(Vector2.left * (currentSpeed * Time.deltaTime));
        }

        public void SetMovementSpeed(float speed)
        {
            currentSpeed = speed;
        }
        public void Attack(GameObject target)
        {
            animator.SetBool(IsAttacking, true);
            currentTarget = target;
        }

        public void StrikeCurrentTarget(float damage)
        {
            if (!currentTarget) { return; }

            var health = currentTarget.GetComponent<UnitHealth>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }

        private void UpdateAnimationState()
        {
            if (!currentTarget)
            {
                animator.SetBool(IsAttacking, false); 
            }
        }

    }
}
