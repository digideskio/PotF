using UnityEngine;
using System.Collections;

public class Dismemberment : MonoBehaviour {
	public Animator BG,corpse;
	public enum DismembermentStates {both, left, right, none};
	public GameObject bothLimbsIntact, leftLimbGone, rightLimbGone, noLimbsLeft, currentLimbObject, Walkie;
	public DismembermentStates currentState = DismembermentStates.none;
	public Animator leftLimbDismemberment, rightLimbDismemberment;

	void Start(){
		SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.water);
		SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.nightAmbience);
		SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.insignificance);
	}

	public void DismemberRight() {
		if (currentState == DismembermentStates.none) {
			currentState = DismembermentStates.left;
			print("right");
		}
		else if (currentState == DismembermentStates.right)
			currentState = DismembermentStates.both;
		UpdateCorpse ();
		GameObject.Find ("hitR").GetComponent<AudioSource> ().Play ();
	}

	public void DismemberLeft() {
		if (currentState == DismembermentStates.none)
			currentState = DismembermentStates.right;
		else if (currentState == DismembermentStates.left)
			currentState = DismembermentStates.both;
		UpdateCorpse ();
		GameObject.Find ("hitL").GetComponent<AudioSource> ().Play ();


	}

	void UpdateCorpse () {
		switch (currentState) {
		case DismembermentStates.none : currentLimbObject = bothLimbsIntact; currentLimbObject.SetActive(true); break;
		case DismembermentStates.left : currentLimbObject.SetActive(false); currentLimbObject = leftLimbGone; currentLimbObject.SetActive(true); print("stateleft");break;
		case DismembermentStates.right : currentLimbObject.SetActive(false); currentLimbObject = rightLimbGone; currentLimbObject.SetActive(true); print("stateright");break;
		case DismembermentStates.both : currentLimbObject.SetActive(false); currentLimbObject = noLimbsLeft; currentLimbObject.SetActive(true); StartCoroutine("StartWalkie");break;
		}	
	}

	IEnumerator StartWalkie () {
		yield return new WaitForSeconds (3);
		noLimbsLeft.GetComponent<FadeOut> ().StartFade ();
		BG.SetTrigger ("fadeOut");
		Walkie.GetComponent<WalkieHandler>().StartWalkie();
	}
}
