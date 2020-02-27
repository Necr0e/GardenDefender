using Enemy;
using UnityEngine;

namespace Global
{
    public class Projectile : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private float projectileSpeed = 1f;
        [SerializeField] private int damage = 100;
        private float projectileLifetime = 10f;
#pragma warning restore 0649
        private void Awake()
        {
            Destroy(gameObject, projectileLifetime);
        }
        private void Update()
        {
            MoveProjectile();
        }

        private void MoveProjectile()
        {
            transform.Translate(Vector2.right * (projectileSpeed * Time.deltaTime));
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            var health = other.GetComponent<UnitHealth>();
            var attacker = other.GetComponent<Attacker>();
            if (attacker && health)
            {
                health.DealDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
