using UnityEngine;
using System.Collections;

public class OpenBackBack : MonoBehaviour {

	public GameObject bp1, bp2;
	public Animator pink1;
	bool isOpened = false, done = false;

	void OnMouseDown () {
		if (isOpened == false) {
			bp1.SetActive (false);
			bp2.SetActive (true);
			isOpened = true;
			GameObject.Find("bpO").GetComponent<AudioSource>().Play ();

		}

		else if (isOpened && done == false) {
			bp2.GetComponent<FadeOut>().StartFade();
			done = true;
			pink1.SetTrigger("fade");
			GameObject.Find ("LeftOar").GetComponent<SliceOar>().canSlice = true;
			GameObject.Find ("RightOar").GetComponent<SliceOar>().canSlice = true;
			GameObject.Find("bpR").GetComponent<AudioSource>().Play ();
			StartCoroutine("Kill");
		}
	}

	IEnumerator Kill(){
		yield return new WaitForSeconds (1.5f);
		GameObject.Find ("kill").GetComponent<AudioSource> ().Play ();
	}
	
	
}
