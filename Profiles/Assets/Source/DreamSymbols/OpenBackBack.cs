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
		}

		else if (isOpened && done == false) {
			bp2.GetComponent<FadeOut>().StartFade();
			done = true;
			pink1.SetTrigger("fade");
			GameObject.Find ("LeftOar").GetComponent<SliceOar>().canSlice = true;
			GameObject.Find ("RightOar").GetComponent<SliceOar>().canSlice = true;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
