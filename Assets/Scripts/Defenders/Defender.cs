using UnityEngine;
namespace Defenders
{
    public class Defender : MonoBehaviour
    {
#pragma warning disable 0414
        [SerializeField] private int resourceCost = 100;
#pragma warning restore 0414
        public void AddResources(int amount)
        {
            FindObjectOfType<UI.Resources>().AddResources(amount);
        }

        public int GetCost()
        {
            return resourceCost;
        }
    }
}
