﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System;

public class SubLevelAsset {
	
	/*
	This class allows us to create an extension to the unity menu which allows us to create Dialogue Assets 
	which can be customized in an inspector. Because the chat interface requires dialogue data to be stored
	and loaded in each level, the other option is to use abunch of XML or JSON files and load them in when the game starts
	or have a public instance of your data class inside of the class that needs the data. However, as Jacob Pennock states,
	creating a custom asset file is the best solution.
	*/
	
	[MenuItem("Assets/Create/SubLevel")]
	public static void CreateAsset ()
	{
		CustomAssetUtility.CreateAsset<SubLevelElement>(); //holds the strings naming the sublevels of each instance of interactivity
	}
}
#endif
