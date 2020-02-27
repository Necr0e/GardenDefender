using UnityEngine;

namespace Global
{
    public class UnitHealth : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private float health = 50f;
        [SerializeField] private GameObject deathVfx;
        private const float DeathVfxLifetime = 2f;
#pragma warning restore 0649
        public void DealDamage(float damage)
        {
            health -= damage;
            KillObject();
        }

        private void KillObject()
        {
            if (health <= 0)
            {
                TriggerDeathVfx();
                Destroy(gameObject);
            }
        }
    
        private void TriggerDeathVfx()
        {
            if (!deathVfx) { return; }
            GameObject deathVfxObject = Instantiate(deathVfx, transform.position, Quaternion.identity);
            Destroy(deathVfxObject, DeathVfxLifetime);
        }
    }
}
