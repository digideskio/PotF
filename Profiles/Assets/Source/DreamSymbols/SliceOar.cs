using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliceOar : MonoBehaviour {

	public GameObject leftArm, rightArm;
	public GameObject corpse;
	public bool isRight;
	public Animator thisOar;
	void Start() {
		thisOar = GetComponent<Animator> ();
	}

	void OnMouseDown() {
		thisOar.SetTrigger ("Slice");
		if (!isRight) {
			print ("pull right");
			corpse.GetComponent<Dismemberment> ().DismemberRight ();
			leftArm.SetActive(true);
			leftArm.GetComponent<Animator>().SetTrigger("Slice");
		}
		else {
			corpse.GetComponent<Dismemberment> ().DismemberLeft ();
			rightArm.SetActive(true);
			rightArm.GetComponent<Animator>().SetTrigger("Slice");

		}
	}

}
