using UnityEngine;
using System.Collections;

public class SoundtrackManager : MonoBehaviour {

	public AudioSource[] arrayOfAudioSources;
	public AudioSource current1, current2, current3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator FadeOutAudioSource(AudioSource x) {
		int counter = 10;
		while (x.volume > 0) {
			x.volume -= .1;
		}
	}

	public void PlayAudioSource() {

	}
}
