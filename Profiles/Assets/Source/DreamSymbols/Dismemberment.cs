using UnityEngine;
using System.Collections;

public class Dismemberment : MonoBehaviour {

	public enum DismembermentStates {both, left, right, none};
	public GameObject bothLimbsIntact, leftLimbGone, rightLimbGone, noLimbsLeft, currentLimbObject;
	public DismembermentStates currentState = DismembermentStates.none;
	public Animator leftLimbDismemberment, rightLimbDismemberment;

	public void DismemberRight() {
		if (currentState == DismembermentStates.none) {
			currentState = DismembermentStates.left;
			print("right");
		}
		else if (currentState == DismembermentStates.right)
			currentState = DismembermentStates.both;
		UpdateCorpse ();
		print ("updateR");
		print (currentState);
	}

	public void DismemberLeft() {
		if (currentState == DismembermentStates.none)
			currentState = DismembermentStates.right;
		else if (currentState == DismembermentStates.left)
			currentState = DismembermentStates.both;
		UpdateCorpse ();
		print ("updateL");
		print (currentState);


	}

	void UpdateCorpse () {
		switch (currentState) {
		case DismembermentStates.none : currentLimbObject = bothLimbsIntact; currentLimbObject.SetActive(true); break;
		case DismembermentStates.left : currentLimbObject.SetActive(false); currentLimbObject = leftLimbGone; currentLimbObject.SetActive(true); print("stateleft");break;
		case DismembermentStates.right : currentLimbObject.SetActive(false); currentLimbObject = rightLimbGone; currentLimbObject.SetActive(true); print("stateright");break;
		case DismembermentStates.both : currentLimbObject.SetActive(false); currentLimbObject = noLimbsLeft; currentLimbObject.SetActive(true); print("statenone");break;
		}	
	}
}
