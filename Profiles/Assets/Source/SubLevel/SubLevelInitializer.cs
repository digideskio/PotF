using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubLevelInitializer : MonoBehaviour {

	public GameObject mazeButton, autosymbolismButton, chatButton, flashbackButton;
	public SubLevel subLevelData;
	// looks at ProgressManager to initialize buttons which lead to other level using their string values which are called from sublevelassets
	void Start ()
	{
		if (ProgressManager.AutoSymbolism == true && subLevelData.SubLevelItems[ProgressManager.subLevel].Autosymbolism != "")
		{
			autosymbolismButton.GetComponentInChildren<Text>().text = subLevelData.SubLevelItems[ProgressManager.subLevel].Autosymbolism;
			autosymbolismButton.SetActive(true);
		}

		if (ProgressManager.Maze == true && subLevelData.SubLevelItems[ProgressManager.subLevel].Maze != "")
		{
			mazeButton.GetComponentInChildren<Text>().text = subLevelData.SubLevelItems[ProgressManager.subLevel].Maze;
			mazeButton.SetActive(true);
		}

		if (ProgressManager.Chat == true && subLevelData.SubLevelItems[ProgressManager.subLevel].Chat != "")
		{
			chatButton.GetComponentInChildren<Text>().text = subLevelData.SubLevelItems[ProgressManager.subLevel].Chat;
			chatButton.SetActive(true);
		}

		if (ProgressManager.FlashBack == true && subLevelData.SubLevelItems[ProgressManager.subLevel].Flashback != "")
		{
			flashbackButton.GetComponentInChildren<Text>().text = subLevelData.SubLevelItems[ProgressManager.subLevel].Flashback;
			flashbackButton.SetActive(true);
		}
	}
}