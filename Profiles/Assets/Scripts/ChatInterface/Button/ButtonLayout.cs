using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonLayout : MonoBehaviour {

	public List<GameObject> buttonList; //list of buttons as established in inspector
	public float buttonVerticalDistance, buttonHorizontalDistance; //spacing between buttons

	void Awake ()
	{
		DeactivateAll ();
	}
	
	public void Activate(List<string> wordChoices) //where wordChoices from dialogue asset
	{
		for (int i = 0; i < wordChoices.Count; i++) //wordChoices.Count
		{
			buttonList[i].gameObject.SetActive(true); //enables text
			buttonList[i].GetComponentInChildren<Text>().text = wordChoices[i]; //sets button text equal to text from Dialogue asset
		}
	}

	public void DeactivateAll()
	{
		foreach (GameObject button in buttonList) {
			button.SetActive(false); //disables text
		}
	}
}
