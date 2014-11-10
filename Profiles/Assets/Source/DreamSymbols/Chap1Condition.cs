using UnityEngine;
using System.Collections;

public class Chap1Condition : MonoBehaviour {

	public Animator leftOar, rightOar;
	public GameObject walkie;
	public Animator BG;
	// Update is called once per frame
	void Update () {
		if (leftOar.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Final")
		    &&
		    rightOar.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Final"))
			StartCoroutine ("FadeOutOars");
	}

	IEnumerator FadeOutOars() {
		print ("Fade Out");
		yield return new WaitForSeconds (3);
		leftOar.GetComponent<Animator> ().SetTrigger ("End");
		rightOar.GetComponent<Animator> ().SetTrigger ("End");
		yield return new WaitForSeconds (3);
		walkie.GetComponentInChildren<WalkieHandler> ().StartWalkie ();
		BG.SetTrigger ("fadeOut");
	}
}
