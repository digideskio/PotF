using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

	public AudioSource soundtrack;
	bool hasWon = false;
	public GameObject picture;

	void Start(){
		picture = GameObject.Find ("Portrait");
		picture.GetComponent<MeshRenderer> ().material.color = new Color (1f, 1f, 1f, 0f);
		SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.nightAmbience);
		SoundtrackManager.s_instance.megaAmbient.volume = 0.1f;
		if (soundtrack!=null){soundtrack.Play ();
		}
	}

	void OnTriggerEnter() {
		if (!hasWon) {
			hasWon = true;
			StartCoroutine ("Win");
			StartCoroutine ("FadeInPicture");

		}
	}

	IEnumerator Win() {
			SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.garby);
			SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.nightAmbience);

			StartCoroutine ("FadeOutAudioSource", soundtrack);
			Time.timeScale = 0.5f;
			GameObject.Find ("PortraitText").GetComponent<FadeIn> ().StartFade ();
			yield return new WaitForSeconds (10f);
			GameObject.Find ("whiteOut").GetComponent<FadeIn>().StartFade();
			yield return new WaitForSeconds (4f);
			Time.timeScale = 1f;
			SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.garby);
			Screen.lockCursor = false;
			Application.LoadLevel (GameManager.s_instance.subLevel.ToString());

	}

	IEnumerator FadeOutAudioSource(AudioSource x) { //call from elsewhere
		while (x.volume > 0.0f) {					//where x is sound track file
			x.volume -= 0.1f;
			yield return new WaitForSeconds(0.3f);
		}
		x.Stop ();
	}

	IEnumerator FadeInPicture() { //call from elsewhere
		float faderFloat = 0;
		while (picture.GetComponent<MeshRenderer>().material.color.a < 1.0f) {					//where x is sound track file
			picture.GetComponent<MeshRenderer>().material.color = new Color (1,1,1,faderFloat);
			faderFloat+=.03f;
			yield return new WaitForSeconds(0.04f);
		}
	}
}
