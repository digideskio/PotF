using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))] //adds an audiocomponent

public class VideoController : MonoBehaviour {
	MovieTexture movie;
	void Start(){
		movie = renderer.material.mainTexture as MovieTexture;
		audio.clip = movie.audioClip;
		audio.Play ();
		movie.Play ();
	}

	void Update() {
		if (!movie.isPlaying) {
			GameManager.s_instance.subLevel ++;
			Application.LoadLevel(GameManager.s_instance.subLevel.ToString());
		}
	}
}

