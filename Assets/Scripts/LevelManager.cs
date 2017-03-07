﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public float autoAdvanceTime = 0;

	void Awake () {
		SceneManager.sceneLoaded += SceneLoaded;
	}

	public void LoadLevel (string name) {
		Debug.Log("Loading level " + name);
		SceneManager.LoadScene(name);
		StartLevel();
	}

	public void LoadNextLevel () {
		int i = SceneManager.GetActiveScene().buildIndex + 1;
		Debug.Log("Loading level " + i);
		SceneManager.LoadScene(i);
		StartLevel();
	}

	public void Quit () {
		Debug.Log("Quitting");
		Application.Quit();
	}

	void SceneLoaded (Scene scene, LoadSceneMode mode) {
		switch (scene.name) {
		case "00_Splash":
			Invoke("LoadNextLevel", autoAdvanceTime);
			break;
		}
	}

	void StartLevel () {
		//Brick.LevelStarted();
		//Gem.LevelStarted();
	}

	public void CheckNextLevel () {
		//if (Brick.NumBreakables == 0 && Gem.NumGems == 0) {
		//	LoadNextLevel();
		//}
	}
}
