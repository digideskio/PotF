using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//sets up what is left to do in each interaction section, or sublevel
public class SubLevelInitializer : MonoBehaviour {

	public GameObject mazeButton, autosymbolismButton, chatButton, flashbackButton;
	public SubLevelElement subLevelData;

	void Start ()
	{
		if (GameManager.s_instance.isAutoSymbolismComplete == false && subLevelData.Autosymbolism != "")
		{
			autosymbolismButton.SetActive(true);
			autosymbolismButton.GetComponentInChildren<Text>().text = subLevelData.Autosymbolism;
			autosymbolismButton.GetComponentInChildren<InnerMenuButton>().levelName = subLevelData.aLevelName;
			autosymbolismButton.SetActive(true);
		}

		//if there is no sublevel data for autosymbolism, call it complete
		else {
			GameManager.s_instance.isAutoSymbolismComplete = true;
		}

		if (GameManager.s_instance.isMazeComplete == true && subLevelData.Maze != "")
		{
			mazeButton.SetActive(true);
			mazeButton.GetComponentInChildren<InnerMenuButton>().levelName = subLevelData.mLevelName;
			mazeButton.GetComponentInChildren<Text>().text = subLevelData.Maze;
			mazeButton.SetActive(true);
		}
		else {
			GameManager.s_instance.isMazeComplete = true;
		}


		if (GameManager.s_instance.isChatComplete == true && subLevelData.Chat != "")
		{
			chatButton.SetActive(true);
			chatButton.GetComponentInChildren<InnerMenuButton>().levelName = subLevelData.cLevelName;
			chatButton.GetComponentInChildren<Text>().text = subLevelData.Chat;
			chatButton.SetActive(true);
		}
		else {
			GameManager.s_instance.isChatComplete = true;
		}


		if (GameManager.s_instance.isFlashbackComplete == true && subLevelData.Flashback != "")
		{
			flashbackButton.SetActive(true);
			flashbackButton.GetComponentInChildren<InnerMenuButton>().levelName = subLevelData.fLevelName;
			flashbackButton.GetComponentInChildren<Text>().text = subLevelData.Flashback;
			flashbackButton.SetActive(true);
		}
		else {
			GameManager.s_instance.isFlashbackComplete = true;
		}

	}
}