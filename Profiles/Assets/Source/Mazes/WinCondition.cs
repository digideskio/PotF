using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

	public AudioSource soundtrack;
	bool hasWon = false;

	void Start(){
		SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.nightAmbience);
		SoundtrackManager.s_instance.megaAmbient.volume = 0.1f;
		if (soundtrack!=null){soundtrack.Play ();
		}
	}

	void OnTriggerEnter() {
		if (!hasWon) {
			hasWon = true;
			StartCoroutine ("Win");
		}
	}

	IEnumerator Win() {
			SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.garby);
			SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.nightAmbience);

			StartCoroutine ("FadeOutAudioSource", soundtrack);
			Time.timeScale = 0.5f;
			GameObject.Find ("PortraitText").GetComponent<FadeIn> ().StartFade ();
			yield return new WaitForSeconds (15f);
			GameObject.Find ("whiteOut").GetComponent<FadeIn>().StartFade();
			yield return new WaitForSeconds (4f);
			Time.timeScale = 1f;
			SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.garby);

			Application.LoadLevel (GameManager.s_instance.subLevel);

	}

	IEnumerator FadeOutAudioSource(AudioSource x) { //call from elsewhere
		while (x.volume > 0.0f) {					//where x is sound track file
			x.volume -= 0.1f;
			yield return new WaitForSeconds(0.3f);
		}
		x.Stop ();
	}
}
