﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageController : MonoBehaviour {

	public Animator image;
	public Image imageGO;
	public Canvas parent;
	public AudioSource diaryBit, onClick;

	void OnMouseEnter()
	{
		if (image.GetCurrentAnimatorStateInfo(0).IsName("Static"))
			diaryBit.Play ();
		image.SetTrigger ("Enter");
		image.ResetTrigger ("Exit");
	}

	void OnMouseExit()
	{
		image.SetTrigger ("Exit");
		image.ResetTrigger ("Enter");
	}

	void OnMouseDown()
	{
		if (FlashBackContainer.flashBackList.Contains(GetComponent<FlashBack> ().flashBack) == false)
		{
			if (image.GetCurrentAnimatorStateInfo(0).IsName("Hover"))
			{
				image.SetTrigger ("Click");
				onClick.Play ();
			}
			GetComponent<FlashBack> ().AddToFlashBackList ();
		}

	}
}
