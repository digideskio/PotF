using UnityEngine;
using System.Collections;

public class Dismemberment : MonoBehaviour {

	public enum DismembermentStates {both, left, right, none};
	public GameObject bothLimbsIntact, leftLimbGone, rightLimbGone, noLimbsLeft, currentLimbObject;
	public DismembermentStates currentState = DismembermentStates.both;
	public Animator leftLimbDismemberment, rightLimbDismemberment;

	public void DismemberRight() {
		if (currentState == DismembermentStates.none)
			currentState = DismembermentStates.right;
		else if (currentState == DismembermentStates.left)
			currentState = DismembermentStates.both;
		rightLimbDismemberment.SetTrigger ("Dismember");
		UpdateCorpse ();
	}

	public void DismemberLeft() {
		if (currentState == DismembermentStates.none)
			currentState = DismembermentStates.left;
		else if (currentState == DismembermentStates.right)
			currentState = DismembermentStates.both;
		leftLimbDismemberment.SetTrigger ("Dismember");
		UpdateCorpse ();
	}

	void UpdateCorpse () {
		switch (currentState) {
		case DismembermentStates.both : currentLimbObject = bothLimbsIntact; currentLimbObject.SetActive(true); break;
		case DismembermentStates.left : currentLimbObject.SetActive(false); currentLimbObject = leftLimbGone; currentLimbObject.SetActive(true); break;
		case DismembermentStates.right : currentLimbObject.SetActive(false); currentLimbObject = rightLimbGone; currentLimbObject.SetActive(true); break;
		case DismembermentStates.none : currentLimbObject.SetActive(false); currentLimbObject = noLimbsLeft; currentLimbObject.SetActive(true); break;
		}

	
	}

}
