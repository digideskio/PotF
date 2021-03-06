﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//sets up what is left to do in each interaction section, or sublevel
public class SubLevelInitializer : MonoBehaviour {

	public GameObject mazeButton, autosymbolismButton, chatButton, flashbackButton;

	void Start ()
	{

		switch (GameManager.s_instance.subLevel) {
		case 1 : SoundtrackManager.s_instance.PlayAudioSource(SoundtrackManager.s_instance.melancholy);break;
		case 2 : SoundtrackManager.s_instance.PlayAudioSource(SoundtrackManager.s_instance.drowning);break;
		case 3 : SoundtrackManager.s_instance.PlayAudioSource(SoundtrackManager.s_instance.ambient);
			flashbackButton = GameObject.Find ("FlashbackButton");
			break;
		case 4 : SoundtrackManager.s_instance.PlayAudioSource(SoundtrackManager.s_instance.melancholy);break;
		case 5 : SoundtrackManager.s_instance.PlayAudioSource(SoundtrackManager.s_instance.jacob);break;
		case 6 : SoundtrackManager.s_instance.PlayAudioSource(SoundtrackManager.s_instance.ambient);break;
		case 7 : SoundtrackManager.s_instance.PlayAudioSource(SoundtrackManager.s_instance.drowning);break;
		case 8 : SoundtrackManager.s_instance.PlayAudioSource(SoundtrackManager.s_instance.ambient);break;
		case 9 : SoundtrackManager.s_instance.PlayAudioSource(SoundtrackManager.s_instance.ambient);break;
		case 10 : SoundtrackManager.s_instance.PlayAudioSource(SoundtrackManager.s_instance.melancholy);break;
		case 11 : SoundtrackManager.s_instance.PlayAudioSource(SoundtrackManager.s_instance.ambient);break;
		}
		if (mazeButton == null)
			GameManager.s_instance.isMazeComplete = true;
		if (autosymbolismButton == null)
			GameManager.s_instance.isAutoSymbolismComplete = true;
		if (chatButton == null)
			GameManager.s_instance.isChatComplete = true;
		if (flashbackButton == null) {
						GameManager.s_instance.isFlashbackComplete = true;
			print("set to true flashback");
			}

		//if there is no button call it complete, and if it is complete, do not show the button, double setting here but who cares
		if (mazeButton != null && GameManager.s_instance.isMazeComplete == true) {
			GameManager.s_instance.isMazeComplete = true;
			if (mazeButton.activeSelf)
				mazeButton.SetActive(false);
		}
		//auto
		if (autosymbolismButton != null && GameManager.s_instance.isAutoSymbolismComplete == true) {
			GameManager.s_instance.isAutoSymbolismComplete = true;
			if (autosymbolismButton.activeSelf)
				autosymbolismButton.SetActive(false);
		}

		//chat
		if (chatButton != null && GameManager.s_instance.isChatComplete == true) {
			GameManager.s_instance.isChatComplete = true;
			if (chatButton.activeSelf)
				chatButton.SetActive(false);
		}

		//flashBack
		if (flashbackButton != null && GameManager.s_instance.isFlashbackComplete == true) {
			GameManager.s_instance.isFlashbackComplete = true;
			if (flashbackButton.activeSelf){
				print ("flashback off");
				flashbackButton.SetActive(false);
			}
		}

		if (GameManager.s_instance.isChatComplete && GameManager.s_instance.isFlashbackComplete
		    && GameManager.s_instance.isMazeComplete && GameManager.s_instance.isAutoSymbolismComplete) {
			GameObject.Find("Leave").GetComponent<Image>().enabled = true;
			GameObject.Find ("Leave").GetComponentInChildren<BoxCollider2D>().enabled = true;
		}


	}
}