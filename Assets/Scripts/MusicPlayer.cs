using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
	public AudioClip[] sceneSongs;

	void Awake () {
		DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += OnLoadedScene;
	}

	// Between Awake and Start is when an audio source starts playing

	void OnLoadedScene (Scene scene, LoadSceneMode mode) {
		AudioSource musicSource = GetComponent<AudioSource>();

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

}
