using System;
using Defenders;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DefenderButton : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private Defender defenderPrefab;
#pragma warning restore 0649
        private TextMeshProUGUI unitCostText;
        private void Awake()
        {
            unitCostText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            UnitToolTip();
        }

        private void OnMouseDown()
        {
            var buttons = FindObjectsOfType<DefenderButton>();
            foreach (DefenderButton button in buttons)
            {
                button.GetComponent<SpriteRenderer>().color = new Color32(41,41,41,255);
                FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
            }
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        private void UnitToolTip()
        {
            if (!unitCostText)
            {
                Debug.LogError(name + " has no cost text!");
            }
            else
            {
                unitCostText.text = defenderPrefab.GetCost().ToString();
            }
        }
    }
}
