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
		while (x.volume > 0.0f) {
			x.volume -= 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
	}

	public void PlayAudioSource() {

	}
}
