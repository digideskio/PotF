using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonLayout : MonoBehaviour {

	public List<GameObject> buttonList; //list of buttons as established in inspector
	public float buttonVerticalDistance, buttonHorizontalDistance; //spacing between buttons
	float topLeftX, topLeftY; //marks position of buttonlayout

	void Awake ()
	{
		DeactivateAll ();
		topLeftX = -450;
		topLeftY = -165;
	}
	
	public void Activate(List<string> wordChoices) //where wordChoices from dialogue asset
	{
		for (int i = 0; i < wordChoices.Count; i++) //wordChoices.Count
		{
//			Vector3 ButtonPosition = new Vector3 (topLeftX + (i % 4) * (buttonHorizontalDistance), topLeftY + ((Mathf.FloorToInt(i / 4)) * buttonVerticalDistance), 0.0f); //places buttons relative to canvas
//			buttonList[i].transform.position = ButtonPosition; //stupid error ruined this code so fuck it all
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
