using UnityEngine;

namespace Global
{
    public class PlayerPrefsController : MonoBehaviour
    {
        private const string MasterVolumeKey = "Master Volume";
        private const float MinVolume = 0f;
        private const float MaxVolume = 1f;
        private const string DifficultyKey = "Difficulty";
        private const float minDifficult = 1f;
        private const float maxDifficulty = 3f;

        public static void SetMasterVolume(float volume)
        {
            if (volume >= MinVolume && volume <= MaxVolume)
            {
                PlayerPrefs.SetFloat(MasterVolumeKey, volume);
            }
            else
            {
                Debug.LogError("Volume is out of range");
            }
        }

        public static float GetMasterVolume()
        {
            return PlayerPrefs.GetFloat(MasterVolumeKey);
        }
        //1: normal, 2: medium, 3: hard
        public static void SetDifficulty(float difficulty)
        {
            if (difficulty >= minDifficult && difficulty <= maxDifficulty)
            {
                PlayerPrefs.SetFloat(DifficultyKey, difficulty);
            }
            else
            {
                Debug.LogError("Difficulty is out of range");
            }
        }

        public static float GetDifficulty()
        {
            return PlayerPrefs.GetFloat(DifficultyKey);
        }
    }
}
