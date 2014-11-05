using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FlashBackContainer : MonoBehaviour {

	public GameObject submit, reset;
	public List<string> flashBackNames;
	public List<Text> listOfTextObjs;

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
		for (int i = 0; i < flashBackList.Count; i++)
		{
			switch (flashBackList[i])
			{
			case FlashBacks.First : listOfTextObjs[i].text = flashBackNames[0]; break;
			case FlashBacks.Second : listOfTextObjs[i].text = flashBackNames[1]; break;
			case FlashBacks.Third : listOfTextObjs[i].text = flashBackNames[2]; break;
			}
		}

		if (flashBackList.Count > 0)
		{
			reset.SetActive(true);
		}

		if (flashBackList.Count == 0)
		{
			submit.SetActive (false);
			reset.SetActive (false);
			listOfTextObjs[0].text = "";
			listOfTextObjs[1].text = "";
			listOfTextObjs[2].text = "";
		}
		if (flashBackList.Count == 3)
			if (flashBackList[0] == FlashBacks.First && flashBackList[1] == FlashBacks.Second && flashBackList[2] == FlashBacks.Third)
				submit.SetActive(true);


	}


}


