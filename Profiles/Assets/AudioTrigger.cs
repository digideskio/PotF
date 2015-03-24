using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour {


	AudioSource audiobit;
	// Use this for initialization
	void Start () {
		audiobit = GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter() {
		if (audiobit.isPlaying == false) {
			audiobit.Play();
		}
	}
}
