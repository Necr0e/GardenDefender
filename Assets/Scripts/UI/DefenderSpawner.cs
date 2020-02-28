using Defenders;
using UnityEngine;

namespace UI
{
    public class DefenderSpawner : MonoBehaviour
    {
        private Camera mainCamera;
        private Defender defender;
        private Resources resources;

        private void Awake()
        {
            mainCamera = Camera.main;
            resources = FindObjectOfType<Resources>();
        }
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
            if (defender)
            {
                int unitCost = defender.GetCost();
                if (resources.HasResources(unitCost))
                {
                    SpawnDefender(gridPos);
                    resources.SpendResources(unitCost);
                }
            }

            else
            {
                //TODO: play error sound to tell player he has to select a defender
            }
        }
        private Vector2 GetSquareClicked()
        {
            var clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPos = mainCamera.ScreenToWorldPoint(clickPos);
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
