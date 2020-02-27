using TMPro;
using UnityEngine;

namespace UI
{
    public class Resources : MonoBehaviour
    {
        [SerializeField] private int currentResources = 100;
        private TextMeshProUGUI resourceText;
        private void Start()
        {
            resourceText = GetComponent<TextMeshProUGUI>();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            resourceText.text = currentResources.ToString();
        }

        public bool HasResources(int amount)
        {
            return currentResources >= amount;
        }
        public void AddResources(int amount)
        {
            if (currentResources <= 999)
            {
                currentResources += amount;
                resourceText.color = Color.white;
                UpdateDisplay();
            }

            if (currentResources >= 1000)
            {
                currentResources = 999;
                resourceText.color = Color.red;
                UpdateDisplay();
            }
        }
        public void SpendResources(int amount)
        {
            if (currentResources >= amount)
            {
                currentResources -= amount;
                UpdateDisplay();
            }
        }
    }
}
