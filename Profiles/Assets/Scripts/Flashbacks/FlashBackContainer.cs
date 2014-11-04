using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FlashBackContainer : MonoBehaviour {

	public GameObject submit, reset;
	public List<string> flashBackNames;
	public Text firstText, secondText, thirdText;

	public static List<FlashBacks> flashBackList;

	public static void AddToFlashBack(FlashBacks flashBack)
	{
		flashBackList.Add (flashBack);
	}

	void Awake()
	{
		flashBackList = new List<FlashBacks> ();
	}

	public static void ResetFlashbacks ()
	{
		flashBackList.Clear ();
	}

	void Update()
	{
		if (flashBackList.Count > 0)
		{
			reset.SetActive (true);
			if (flashBackList[0] == FlashBacks.First)
				firstText.text = flashBackNames[0];
			if (flashBackList.Count > 1)
			{
				if (flashBackList[1] == FlashBacks.Second)
					secondText.text = flashBackNames[1];
				if (flashBackList.Count > 2)
				{
					if (flashBackList[2] == FlashBacks.Third)
						thirdText.text = flashBackNames[2];
				}
			}


		}

		if (flashBackList.Count == 0)
		{
			submit.SetActive (false);
			reset.SetActive (false);
			firstText.text = "";
			secondText.text = "";
			thirdText.text = "";
		}
		if (flashBackList.Count == 3)
			if (flashBackList[0] == FlashBacks.First && flashBackList[1] == FlashBacks.Second && flashBackList[2] == FlashBacks.Third)
				submit.SetActive(true);


	}


}


