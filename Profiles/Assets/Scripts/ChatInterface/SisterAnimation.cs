using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SisterAnimation : MonoBehaviour {

	private int timeCounter = 0;
	private int alphaValue = 0;

	void Awake()
	{
		Color color = guiText.color;
		color.a = alphaValue;
		guiText.color = color;
	}

	void Update()
	{
		timeCounter++;

		if (timeCounter > 100)
		{
			alphaValue++;
			Color color = guiText.color;
			color.a = alphaValue;
			guiText.color = color;
		}
	}

}