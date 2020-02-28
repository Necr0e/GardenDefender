using Defenders;
using UnityEngine;

namespace UI
{
    public class DefenderButton : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private Defender defenderPrefab;
#pragma warning restore 0649
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
    }
}
