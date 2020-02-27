using Defenders;
using UnityEngine;

namespace Enemy
{
    public class Lizard : MonoBehaviour
    {
        private Attacker attacker;
        private void Start()
        {
            attacker = GetComponent<Attacker>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            GameObject otherObject = other.gameObject;
            if (otherObject.GetComponent<Defender>())
            {
                attacker.Attack(otherObject);
            }
        }
    }
}
