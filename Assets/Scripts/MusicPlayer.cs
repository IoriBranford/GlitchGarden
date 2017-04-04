using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
	public AudioClip[] sceneSongs;

	private AudioSource musicSource;

	void Awake () {
		DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += OnLoadedScene;
		musicSource = GetComponent<AudioSource>();
	}

	// Between Awake and Start is when an audio source starts playing

	void OnLoadedScene (Scene scene, LoadSceneMode mode) {
		AudioClip nextSong = sceneSongs[scene.buildIndex];
		if (nextSong) {
			if (nextSong != musicSource.clip) {
				musicSource.Stop();
				musicSource.clip = nextSong;
				musicSource.loop = (scene.buildIndex != 0);
				musicSource.Play();
			}
		} else {
			musicSource.Stop();
		}
	}

	public void SetVolume (float volume) {
		musicSource.volume = volume;
	}
}
