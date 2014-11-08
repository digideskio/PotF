using UnityEngine;
using System.Collections;

public class SubmitButton : MonoBehaviour {

	public GameObject submit, reset, fadeIn;
	public AudioSource audioDiary, jason, splash;
	bool isPressed = false;


	public void Submit()
	{
		FlashBackContainer.ResetFlashbacks ();
		fadeIn.SetActive (true);
		submit.SetActive (false);
		reset.SetActive (false);
		audioDiary.Play ();
		jason.Play ();
		splash.Play ();
		isPressed = true;
		GameObject.FindGameObjectWithTag ("StoryPlayer").GetComponent<PhotoPlayer> ().StartSlideShow ();
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
