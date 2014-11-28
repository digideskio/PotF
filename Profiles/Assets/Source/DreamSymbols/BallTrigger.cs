using UnityEngine;
using System.Collections;

public class BallTrigger : MonoBehaviour {

	public GameObject PinkShirtReachOut;
	
	// Update is called once per frame
	void Update () {
		if (PinkShirtReachOut.activeSelf == true)
			gameObject.GetComponent<Animator> ().SetTrigger ("Fade");

	}
}
