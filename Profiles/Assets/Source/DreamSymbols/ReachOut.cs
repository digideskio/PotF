﻿using UnityEngine;
using System.Collections;

public class ReachOut : MonoBehaviour {

	public GameObject pink1, pink2;
	bool hasNotReachedOut = true;

	void OnMouseDown ()
	{
		print ("reach");
		if (hasNotReachedOut)
		{
			pink1.SetActive (false);
			pink2.SetActive (true);
			hasNotReachedOut = false;
			GameObject.Find("baseballHit").GetComponent<AudioSource>().Play();
			GameObject.Find("cL").GetComponent<AudioSource>().Play();

			StartCoroutine("PlayWalkie");
		}
	}

	IEnumerator PlayWalkie() {
		yield return new WaitForSeconds (4);
		Chap2Condition.s_instance.TriggerWalkie ();

	}


}
