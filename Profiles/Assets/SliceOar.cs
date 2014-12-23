using UnityEngine;
using System.Collections;

public class SliceOar : MonoBehaviour {

	public GameObject corpse;

	Animator thisOar;
	void Start() {
		thisOar = GetComponent<Animator> ();
	}

	void OnMousedown() {
		print ("trigger");
		thisOar.SetTrigger ("Slice");
	}


}
