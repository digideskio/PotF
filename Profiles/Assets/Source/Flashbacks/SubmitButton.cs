using UnityEngine;
using System.Collections;

public class SubmitButton : MonoBehaviour {

	public GameObject submit, reset, fadeIn;
	public AudioSource jason, splash;
	bool isPressed = false;


	public void Submit()
	{
		FlashBackContainer.ResetFlashbacks ();
		fadeIn.SetActive (true);
		submit.SetActive (false);
		reset.SetActive (false);
		jason.Play ();
		splash.Play ();
		isPressed = true;
		GameObject.FindGameObjectWithTag ("StoryPlayer").GetComponent<PhotoPlayer> ().StartSlideShow ();
	}

}
