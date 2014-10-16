using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhotoPlayer : MonoBehaviour {

	public List<GameObject> photos;
	public float skipRate;
	int counter = 0;

	public void OnClick ()
	{
		StopCoroutine (PlayPhotos());
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
		photos[counter].SetActive(true);
		StartCoroutine (PlayPhotos());
	}


	IEnumerator PlayPhotos ()
	{
		while (true)
		{
			yield return new WaitForSeconds(skipRate);
			SkipPhoto ();
		}
	}
}
