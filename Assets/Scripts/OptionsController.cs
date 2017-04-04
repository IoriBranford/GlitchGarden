using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
		volumeSlider.value = GlitchGardenPrefs.MasterVolume;
		difficultySlider.value = GlitchGardenPrefs.Difficulty;

		musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
		Debug.Log(musicPlayer);
	}
	
	// Update is called once per frame
	void Update () {
		if (musicPlayer) {
			musicPlayer.SetVolume(volumeSlider.value);
		}
	}

	public void SaveAndExit () {
		GlitchGardenPrefs.MasterVolume = volumeSlider.value;
		GlitchGardenPrefs.Difficulty = difficultySlider.value;

		levelManager.LoadLevel("01_Start");
	}

	public void SetDefaults () {
		volumeSlider.value = .8f;
		difficultySlider.value = 2;
	}
}
