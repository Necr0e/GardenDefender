using UnityEngine;
using Defenders;

namespace Enemy
{
    public class Fox : MonoBehaviour
    {
        private static readonly int JumpTrigger = Animator.StringToHash("jumpTrigger");
        private Animator animator;
        private Attacker attacker;

        private void Start()
        {
            animator = GetComponent<Animator>();
            attacker = GetComponent<Attacker>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            GameObject otherObject = other.gameObject;

            if (otherObject.GetComponent<Gravestone>())
            {
                animator.SetTrigger(JumpTrigger);
            }
            else if (otherObject.GetComponent<Defender>())
            {
                attacker.Attack(otherObject);
            }
        }
    }
}
