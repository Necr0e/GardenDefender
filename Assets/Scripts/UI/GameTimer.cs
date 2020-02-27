using Global;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameTimer : MonoBehaviour
    {   [Tooltip("Level time in seconds.")]
        [SerializeField] private float levelTime = 60;
        private Slider slider;
        private LevelController gameFinished;
        private bool timerFinished;
        private bool triggeredLevelFinished;
        private void Awake()
        {
            slider = GetComponent<Slider>();
            gameFinished = FindObjectOfType<LevelController>();
        }
        private void Update()
        {
            if (triggeredLevelFinished){ return; }
            slider.value = Time.timeSinceLevelLoad / levelTime;
            timerFinished = (Time.timeSinceLevelLoad >= levelTime);
            if (timerFinished)
            {
                gameFinished.LevelTimerFinished();
                triggeredLevelFinished = true;
            }
        }
    }
}
