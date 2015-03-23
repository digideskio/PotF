using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

	public AudioSource soundtrack;

	void Start(){
		SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.lakeAmbient);
		soundtrack.Play ();
	}

	void OnTriggerEnter() {
		StartCoroutine ("Win");
	}

	IEnumerator Win() {
		Time.timeScale = 0.5f;
		GameObject.Find ("PortraitText").GetComponent<FadeIn> ().StartFade ();
//		GameManager.s_instance.PlayAudioFile ("winMaze");
		yield return new WaitForSeconds (7f);
		GameObject.Find ("whiteOut").GetComponent<FadeIn>().StartFade();
		yield return new WaitForSeconds (4f);
		Time.timeScale = 1f;
		SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.megaAmbient);
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
