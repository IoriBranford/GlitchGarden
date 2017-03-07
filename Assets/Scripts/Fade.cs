using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {
	public bool fadeIn = true;
	public float fadeTime = 1;

	private Image _image;
	private float _fadeDirection;

	// Use this for initialization
	void Start () {
		_image = GetComponent<Image>();

		Color color = _image.color;
		if (fadeIn) {
			color.a = 1;
		} else {
			color.a = 0;
		}
		_image.color = color;
		_fadeDirection = fadeIn ? -1 : 1;
	}

	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeTime) {
			Color color = _image.color;
			color.a += _fadeDirection * Time.deltaTime / fadeTime;
			_image.color = color;
		} else {
			gameObject.SetActive(false);
		}
	}
}
