using UnityEngine;
using System.Collections;

public class BallTrigger : MonoBehaviour {

	public GameObject PinkShirtReachOut, Chap2ConditionHolder;
	bool hasBeenCalled = true;
	// Update is called once per frame
	void Update () {
		if (PinkShirtReachOut.activeSelf == true && hasBeenCalled)
		{
			StartCoroutine("FadeBall");
			hasBeenCalled = false;
		}
	}

	IEnumerator FadeBall ()
	{
		yield return new WaitForSeconds (3);
		gameObject.GetComponent<Animator> ().SetTrigger ("Fade");
	}

	void OnMouseDown()
	{
		if (gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.a1"))
			Chap2ConditionHolder.GetComponent<Chap2Condition> ().TriggerWalkie ();
	}	
}
