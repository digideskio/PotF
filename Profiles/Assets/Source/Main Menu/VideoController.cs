using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))] //adds an audiocomponent

public class VideoController : MonoBehaviour {
	public MovieTexture[] movies;
	void Start(){
		movies[GameManager.s_instance.subLevel] = renderer.material.mainTexture as MovieTexture;
		audio.clip = movies[GameManager.s_instance.subLevel].audioClip;
		audio.Play ();
		movies[GameManager.s_instance.subLevel].Play ();
	}

	void Update() {
		if (!movies[GameManager.s_instance.subLevel].isPlaying) {
			EndVideoScene();	
		}

		if (Input.GetMouseButtonDown (0)) { //for testing
			EndVideoScene();	
		}
	}

	void EndVideoScene() {

		GameManager.s_instance.subLevel ++;
		Application.LoadLevel("MainMenu");

	}
}

