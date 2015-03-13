using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhotoPlayer : MonoBehaviour {

	public List<GameObject> photos;
	public float skipRate, pause;
	int counter = 0;
	bool isPlaying;

	public void OnClick ()
	{
		StopAllCoroutines ();
		SkipPhoto ();
		StartCoroutine (PlayPhotos());
	}

	void SkipPhoto ()
	{
		if (counter < photos.Count - 1)
		{
			counter+=1;
			photos[counter].SetActive(true); //show next photo
			photos[counter-1].SetActive(false); //hide previos photo
		}

		else
		{
			counter = 0;
			photos[counter].SetActive(true); //show next photo
			photos[photos.Count - 1].SetActive(false); //hide previos photo
		}
	}

	public void StartSlideShow ()
	{
		SoundtrackManager.s_instance.PlayAudioSource(SoundtrackManager.s_instance.wind);
		StartCoroutine ("LoadMenu");
		print ("slideshow");
		isPlaying = true;
		photos[counter].SetActive(true);
		StartCoroutine ("Pause");
	}

	IEnumerator Pause()
	{
		yield return new WaitForSeconds (pause);
		StartCoroutine (PlayPhotos());
	}

	IEnumerator PlayPhotos ()
	{
		while (isPlaying)
		{
			yield return new WaitForSeconds(skipRate);
			SkipPhoto ();
		}
	}

	IEnumerator LoadMenu() {
		print ("LoadMenu");
		yield return new WaitForSeconds (10);
		SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.wind);
		print ("loading");
		Application.LoadLevel(GameManager.s_instance.subLevel.ToString());
	}

	void Update()
	{
		if (isPlaying)
		{
			if(Input.GetMouseButtonDown(0))	
				OnClick();
		}

	}

}
