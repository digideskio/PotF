using UnityEngine;
using System.Collections;


public class SubmitButton : MonoBehaviour {

	public GameObject submit, reset;
	public AudioSource jason, splash, one, two, three, four, five;
	bool isPressed = false;


	public void Submit()
	{
		GameObject.FindGameObjectWithTag ("StoryPlayer").GetComponent<PhotoPlayer> ().StartSlideShow ();
		FlashBackContainer.ResetFlashbacks ();
		submit.SetActive (false);
		reset.SetActive (false);
		if (one != null)
			one.Play ();
		if (two != null)
			two.Play ();
		if (three != null)
			three.Play ();
		if (four != null)
			four.Play ();
		if (five != null)
			five.Play ();
		jason.Play ();
		splash.Play ();
		isPressed = true;
	}

}
