using UnityEngine;
namespace Global
{
    public class LoseCollider : MonoBehaviour
    {
        private PlayerLives lifeCount;
        private void Awake()
        {
            lifeCount = FindObjectOfType<PlayerLives>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            lifeCount.TakeLife();
        }
    }
}
