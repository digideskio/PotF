using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager s_instance;
	public bool isMazeComplete, isChatComplete, isAutoSymbolismComplete, isFlashbackComplete;
	void Awake() {
		s_instance = this;
		DontDestroyOnLoad (gameObject);
	}

	public int subLevel = 0;

	public void MarkAsComplete(LevelType level) {
		switch (level) {
		case LevelType.AutoSymbolism : isAutoSymbolismComplete = true; break;
		case LevelType.Chat : isChatComplete = true; break;
		case LevelType.Maze : isMazeComplete = true; break;
		case LevelType.Flashback : isFlashbackComplete = true; break;
		}
	}

	public void LoadNext() {
		subLevel ++;
		if (subLevel == 6)
			Application.LoadLevel ("maze1"); //in the one case that you have to go from video to maze
		else
			Application.LoadLevel (subLevel.ToString ());

	}

	//for the beginning where you can skip to a chapter
	public void LoadLevel(int i) {
		Application.LoadLevel (i.ToString ());
	}

	public void MarkAllIncomplete () {
		isMazeComplete = false;
		isChatComplete = false;
		isFlashbackComplete = false;
		isAutoSymbolismComplete = false;
	}

}
