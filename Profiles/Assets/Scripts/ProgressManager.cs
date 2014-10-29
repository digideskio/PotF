using UnityEngine;
using System.Collections;

public class ProgressManager : MonoBehaviour {

	public static int level = 1;
	public static int subLevel = 1;

	public static void IncrementLevel()
	{
		level ++;
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
