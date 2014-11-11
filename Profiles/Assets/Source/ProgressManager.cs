using UnityEngine;
using System.Collections;


public class ProgressManager : MonoBehaviour {

	public static int level = 1;
	public static int subLevel = 1;
	public static bool AutoSymbolism = true;
	public static bool FlashBack = true;
	public static bool Maze = true;
	public static bool Chat = true;


	public static void IncrementLevel()
	{
		level ++;
		ResetSubLevel ();
	}

	public static void IncrementSubLevel()
	{
		subLevel ++;
		MakeChallengesTrue ();
	}

	public static void ResetSubLevel ()
	{
		subLevel = 1;
		MakeChallengesTrue ();
	}

	static void MakeChallengesTrue ()
	{
		AutoSymbolism = true;
		FlashBack = true;
		Maze = true;
		Chat = true;
	}
}
