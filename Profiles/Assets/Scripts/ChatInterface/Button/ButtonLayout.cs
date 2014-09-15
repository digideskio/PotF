using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonLayout : MonoBehaviour {

	public List<Button> buttonList; //list of buttons as established in inspector/prefab which hold text values/receive input
	public float buttonVerticalDistance, buttonHorizontalDistance; //spacing between buttons
	float topLeftX, topLeftY; //marks position of buttonlayout

	void Awake ()
	{
		DeactivateAll ();
		topLeftX = buttonList [0].GetComponent<RectTransform> ().anchoredPosition.x; //sets up the button layout with respect to first button for designability
		topLeftY = buttonList [0].GetComponent<RectTransform> ().anchoredPosition.y;
	}
	
	public void Activate(List<string> wordChoices) //where wordChoices from dialogue asset
	{
		for (int i = 0; i < wordChoices.Count; i++)
		{
			buttonList[i].transform.localPosition = new Vector3 (topLeftX + (i % 4) * (buttonHorizontalDistance), topLeftY + ((Mathf.FloorToInt(i / 4)) * buttonVerticalDistance), 0.0f); //places buttons relative to canvas
			buttonList[i].GetComponentInChildren<Text>().text = wordChoices[i]; //sets button text equal to text from Dialogue asset
			buttonList[i].interactable = true; //makes button visible/usable                                                                             										
		}
	}

	public void DeactivateAll()
	{
		foreach (Button button in buttonList)
			button.interactable = false; //deactivates all buttons
	}
}
