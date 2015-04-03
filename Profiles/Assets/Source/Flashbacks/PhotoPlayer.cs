using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public enum FlashBackLevel {one,two,three};


public class PhotoPlayer : MonoBehaviour {

	public List<GameObject> photos;
	public float skipRate, pause, waitTimeBeforeLoad;
	int counter = 0;
	bool isPlaying, countdown = false;
	public FlashBackLevel thislevel;
	float timer,startTime;

	void Start() {

	}

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
		startTime = Time.time;
		countdown = true;
		switch (thislevel) {
		case FlashBackLevel.one:
			SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.donnie);
			break;
		case FlashBackLevel.two:
			SoundtrackManager.s_instance.PlayAudioSource( SoundtrackManager.s_instance.three);
			SoundtrackManager.s_instance.three.time = 60f;
			break;
		case FlashBackLevel.three:
			SoundtrackManager.s_instance.PlayAudioSource( SoundtrackManager.s_instance.insignificance);
			break;
		}
		SoundtrackManager.s_instance.PlayAudioSource(SoundtrackManager.s_instance.wind);
		SoundtrackManager.s_instance.wind.volume = 0.1f;
		isPlaying = true;
		photos[counter].SetActive(true);
		StartCoroutine ("Pause");
	}

	IEnumerator Pause()
	{
		yield return new WaitForSeconds (skipRate);
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

	void LoadMenu() {
		GameObject.Find ("blackout").GetComponent<Image> ().enabled = true;
		GameObject.Find ("blackout").GetComponent<FadeIn> ().StartFade ();
		SoundtrackManager.s_instance.StartCoroutine ("FadeOutAudioSource", SoundtrackManager.s_instance.wind);
			switch (thislevel) {
			case FlashBackLevel.one:
					SoundtrackManager.s_instance.StartCoroutine ("FadeOutAudioSource", SoundtrackManager.s_instance.donnie);
					break;
			case FlashBackLevel.two:
					SoundtrackManager.s_instance.StartCoroutine ("FadeOutAudioSource", SoundtrackManager.s_instance.three);
					break;
			case FlashBackLevel.three:
					SoundtrackManager.s_instance.StartCoroutine ("FadeOutAudioSource", SoundtrackManager.s_instance.insignificance);
					break;
			}
		StartCoroutine ("Exit");
	}

	void Update()
	{
		if (isPlaying)
		{
			if(Input.GetMouseButtonDown(0))	
				OnClick();
		}
		if (countdown){
			timer = Time.time - startTime;
			if (timer > waitTimeBeforeLoad) {
				LoadMenu();
		}
	}


	}

	IEnumerator Exit(){
		yield return new WaitForSeconds (3f);
		Application.LoadLevel (GameManager.s_instance.subLevel.ToString ());

	}

}
