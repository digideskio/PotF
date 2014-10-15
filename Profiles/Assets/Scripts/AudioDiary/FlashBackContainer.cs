using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlashBackContainer : MonoBehaviour {

	public GameObject submit, reset;

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
			reset.SetActive (true);
		if (flashBackList.Count == 0)
		{
			print ("null");
			reset.SetActive (false);
		}
		if (flashBackList.Count == 3)
			if (flashBackList[0] == FlashBacks.First && flashBackList[1] == FlashBacks.Second && flashBackList[2] == FlashBacks.Third)
				submit.SetActive(true);
	}


}


