using System;
using Global;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class OptionsController : MonoBehaviour
    {
#pragma warning  disable 0649
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private Slider difficultySlider;
#pragma warning restore 0649
#pragma warning disable 0414
        [SerializeField] private float defaultVolume = 0.8f;
        [SerializeField] private float defaultDifficulty = 1f;
#pragma warning restore 0414
        private MusicPlayer musicPlayer;
        private LevelLoader levelLoader;

        private void Awake()
        {
            musicPlayer = FindObjectOfType<MusicPlayer>();
            levelLoader = FindObjectOfType<LevelLoader>();
        }

        private void Start()
        {
            volumeSlider.value = PlayerPrefsController.GetMasterVolume();
            difficultySlider.value = PlayerPrefsController.GetDifficulty();
        }
        private void Update()
        {
            if (musicPlayer)
            {
                musicPlayer.SetVolume(volumeSlider.value);
            }
            else
            {
                Debug.LogWarning("No music player found.");
            }
        }

        public void SaveAndExit()
        {
            PlayerPrefsController.SetMasterVolume(volumeSlider.value);
            PlayerPrefsController.SetDifficulty(difficultySlider.value);
            levelLoader.LoadMainMenu();
        }

        public void ResetToDefault()
        {
            volumeSlider.value = defaultVolume;
            difficultySlider.value = defaultDifficulty;
        }
    }
}
