using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

	void OnTriggerEnter() {
		StartCoroutine ("Win");
	}

	IEnumerator Win() {
		Time.timeScale = 0.5f;
//		GameManager.s_instance.PlayAudioFile ("winMaze");
		yield return new WaitForSeconds (7f);
		GameObject.Find ("whiteOut").GetComponent<FadeIn>().StartFade();
		yield return new WaitForSeconds (4f);
		Time.timeScale = 1f;
		Application.LoadLevel (GameManager.s_instance.subLevel);

	}
}
