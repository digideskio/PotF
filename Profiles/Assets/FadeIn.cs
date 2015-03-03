﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
	
	public bool fadeIn;
	public float startTime, fadeTime = 3;
	Image image;
	SpriteRenderer sprite;
	void Start() {
		sprite = GetComponent<SpriteRenderer> ();
		image = GetComponent<Image> ();
	}
	
	void Update() {
		if (fadeIn) {
			float timePassed = (Time.time - startTime);
			float fracJourney = timePassed / fadeTime;
			if (sprite!=null)
				sprite.color = Color.Lerp (new Color (1f, 1f, 1f, 0f), new Color (1f, 1f, 1f, 1f), fracJourney);
			if (image!=null)
				image.color = Color.Lerp (new Color (1f, 1f, 1f, 0f), new Color (1f, 1f, 1f, 1f), fracJourney);
		}
	}
	
	public void StartFade() {
		startTime = Time.time;
		fadeIn = true;
	}
}