using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Chapter : MonoBehaviour {

	public List<List<GameObject>> ListOfChapterStages;
	public static bool FlashBackIsCompleted = true;
	public static bool MazeIsCompleted = true;
	public static bool ChatIsCompleted = true;
	public static bool AutoSymbolismIsCompleted = true;

	void Start()
	{
		//for each item in current List of Prefabs (where prefabs are sliding buttons with position and title and name of level they load
		//switch(item) and have enum for maze/chat/ etc.. and whichever one it is set that static bool to false
		//we will have to make a bunch of level prefabs in this way
		//
	}
}
