using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonLayout : MonoBehaviour {

	public List<GameObject> ButtonList; //list of buttons as established in inspector/prefab which hold text values/receive input
	public float buttonVerticalDistance, buttonHorizontalDistance; //spacing between buttons
	float topLeftX, topLeftY; //marks position of buttonlayout

	void Awake ()
	{
		topLeftX = ButtonList [0].GetComponent<RectTransform> ().anchoredPosition.x; //sets up the button layout with respect to first button for designability
		topLeftY = ButtonList [0].GetComponent<RectTransform> ().anchoredPosition.y;
	}

	public void Activate(List<string> wordChoices) //where wordChoices from dialogue asset
	{
		for (int i = 0; i < wordChoices.Count; i++)
		{
			RectTransform tempButton = ButtonList[i].GetComponent<RectTransform> ();
			tempButton.anchoredPosition = new Vector2 (topLeftX + (i % 4) * (buttonHorizontalDistance), topLeftY + ((Mathf.FloorToInt(i / 4)) * buttonVerticalDistance)); //places buttons relative to canvas
			tempButton.GetComponent<Text>().text = wordChoices[i]; //sets button text equal to text from Dialogue asset
			ButtonList[i].SetActive(true); //makes button visible                                                                             										
		}
	}

	public void DeactivateAll()
	{
		foreach (GameObject button in ButtonList)
			button.SetActive (false);
	}
}
