using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliceOar : MonoBehaviour {

	public static SliceOar s_instance;

	public GameObject leftArm, rightArm;
	public GameObject corpse;
	public bool isRight, canSlice = false;
	public Animator thisOar;
	void Start() {
		thisOar = GetComponent<Animator> ();
	}

	void OnMouseDown() {
		if (!isRight && canSlice) {
			thisOar.SetTrigger ("Slice");

			corpse.GetComponent<Dismemberment> ().DismemberRight ();
			leftArm.SetActive(true);
			leftArm.GetComponent<Animator>().SetTrigger("Slice");
		}
		else if(isRight && canSlice) {
			thisOar.SetTrigger ("Slice");

			corpse.GetComponent<Dismemberment> ().DismemberLeft ();
			rightArm.SetActive(true);
			rightArm.GetComponent<Animator>().SetTrigger("Slice");

		}
	}

}
