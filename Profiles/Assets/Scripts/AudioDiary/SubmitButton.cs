using UnityEngine;
using System.Collections;

public class SubmitButton : MonoBehaviour {

	public GameObject submit, reset, divisor;
	public AudioSource audioDiary;
	bool isPressed = false;


	public void Submit()
	{
		submit.SetActive (false);
		reset.SetActive (false);
		divisor.SetActive (false);
		audioDiary.Play ();
		isPressed = true;
	}

	void Update()
	{
		if (isPressed)
			if (!audioDiary.isPlaying)
				EndLevel();
	}

	void EndLevel()
	{

	}

}
