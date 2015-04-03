using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))] //adds an audiocomponent

public class VideoController : MonoBehaviour {
	public MovieTexture[] movies;
	void Start(){
		renderer.material.mainTexture = movies [GameManager.s_instance.subLevel];
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
		GameManager.s_instance.MarkAllIncomplete ();
		if (GameManager.s_instance.subLevel != 6)
			Application.LoadLevel("MainMenu");
		else
			Application.LoadLevel("Maze1");

	}
}

