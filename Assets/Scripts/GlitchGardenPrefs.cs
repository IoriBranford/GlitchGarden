using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlitchGardenPrefs : MonoBehaviour {
	const string MasterVolumeKey = "MasterVolume";
	public static float MasterVolume {
		get {
			return PlayerPrefs.GetFloat(MasterVolumeKey);
		}

		set {
			if (value < 0f || value > 1f) {
				Debug.LogError(MasterVolumeKey +
						" must be between 0 and 1");
			} else {
				PlayerPrefs.SetFloat(MasterVolumeKey, value);
			}
		}
	}

	const string DifficultyKey = "Difficulty";
	public static float Difficulty {
		get {
			return PlayerPrefs.GetFloat(DifficultyKey);
		}

		set {
			if (value < 1 || value > 3) {
				Debug.LogError(DifficultyKey +
						" must be between 1 and 3");
			} else {
				PlayerPrefs.SetFloat(DifficultyKey, value);
			}
		}
	}

	const string UnlockedLevelKey = "UnlockedLevel";
	public static void UnlockLevel (int level) {
		if (level < 0 || level >= SceneManager.sceneCountInBuildSettings) {
			Debug.LogError(UnlockedLevelKey +
					" must be between 0 and " +
					SceneManager.sceneCountInBuildSettings);
		} else {
			PlayerPrefs.SetInt(UnlockedLevelKey + level, 1);
		}
	}
	public static bool IsLevelUnlocked (int level) {
		if (level < 0 || level >= SceneManager.sceneCountInBuildSettings) {
			Debug.LogError(UnlockedLevelKey +
					" must be between 0 and " +
					SceneManager.sceneCountInBuildSettings);
			return false;
		}

		return PlayerPrefs.GetInt(UnlockedLevelKey + level) == 1;
	}
}
