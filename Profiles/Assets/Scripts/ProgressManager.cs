using UnityEngine;
using System.Collections;


public class ProgressManager : MonoBehaviour {

	public static int level = 1;
	public static int subLevel = 1;
	public static bool AutoSymbolism = false;
	public static bool FlashBack = false;
	public static bool Maze = false;
	public static bool Chat = false;


	public static void IncrementLevel()
	{
		level ++;
		ResetSubLevel ();
	}

	public static void IncrementSubLevel()
	{
		subLevel ++;
	}

	public static void ResetSubLevel ()
	{
		subLevel = 1;
	}
}
