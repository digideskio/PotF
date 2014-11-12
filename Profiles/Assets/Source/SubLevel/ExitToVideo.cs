using UnityEngine;
using System.Collections;

public class ExitToVideo : MonoBehaviour {

	public int subLevelValue;

	public GameObject challenge1, challenge2, challenge3;

	void Update ()
	{
		if (challenge1.activeSelf == false && challenge2.activeSelf == false && challenge3.activeSelf == false && ProgressManager.subLevel == subLevelValue)
			gameObject.SetActive (true);
	}

}
