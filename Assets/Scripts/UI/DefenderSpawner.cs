using Defenders;
using UnityEngine;

namespace UI
{
    public class DefenderSpawner : MonoBehaviour
    {
        private Defender defender;
        private void OnMouseDown()
        {
            AttemptToPlaceDefender(GetSquareClicked());
        }
        public void SetSelectedDefender(Defender defenderToSelect)
        {
            defender = defenderToSelect;
        }

        private void AttemptToPlaceDefender(Vector2 gridPos)
        {
            var resources = FindObjectOfType<Resources>();
            int unitCost = defender.GetCost();
            if (resources.HasResources(unitCost))
            {
                SpawnDefender(gridPos);
                resources.SpendResources(unitCost);
            }
        }
        private Vector2 GetSquareClicked()
        {
            var clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
            Vector2 gridPos = SnapToGrid(worldPos);
            return gridPos;
        }
        private void SpawnDefender(Vector2 worldPos)
        {
            if (!defender) { return; }
            Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity);
        }
        private Vector2 SnapToGrid(Vector2 rawWorldPos)
        {
            float newX = Mathf.RoundToInt(rawWorldPos.x);
            float newY = Mathf.RoundToInt(rawWorldPos.y);
            return new Vector2(newX, newY);
        }
    }
}
