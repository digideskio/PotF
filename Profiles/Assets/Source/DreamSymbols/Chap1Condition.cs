using UnityEngine;
using System.Collections;

public class Chap1Condition : MonoBehaviour {

	public Animator leftOar, rightOar;
	public GameObject walkie;
	public Animator BG;
	public AudioSource snap, leftA,rightA;
	bool right=false,left=false, hasSnapped=false;

	public void RightTrue(){
		if (!right){
			rightA.Play ();
			right = true;
		}
	}
	public void LeftTrue(){
		if (!left){
			leftA.Play();
			left = true;
		}
	}
	void Start(){
		SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.water);
		SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.nightAmbience);
	}
	// Update is called once per frame
	void Update () {
		if (leftOar.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Final")
		    &&
		    rightOar.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Final"))
			StartCoroutine ("FadeOutOars");
		if (leftOar.GetComponent<Animator>().GetAnimatorTransitionInfo(0).IsName("Base Layer.Final -> Base Layer.Fade Out") && !hasSnapped){
			snap.Play ();
			hasSnapped = true;
		}


	}

	IEnumerator FadeOutOars() {
		yield return new WaitForSeconds (3);
		leftOar.GetComponent<Animator> ().SetTrigger ("End");
		rightOar.GetComponent<Animator> ().SetTrigger ("End");
		yield return new WaitForSeconds (3);
		walkie.GetComponentInChildren<WalkieHandler> ().StartWalkie ();
		BG.SetTrigger ("fadeOut");

	}
}
