using UnityEngine;
using System.Collections;


public class SubmitButton : MonoBehaviour {

	public GameObject submit, reset, fadeIn;
	public AudioSource jason, splash, one, two, three, four, five;
	bool isPressed = false;


	public void Submit()
	{
		FlashBackContainer.ResetFlashbacks ();
		fadeIn.SetActive (true);
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
		GameObject.FindGameObjectWithTag ("StoryPlayer").GetComponent<PhotoPlayer> ().StartSlideShow ();
	}

}
