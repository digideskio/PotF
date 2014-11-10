using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	//List of menu buttons
	public List<GameObject> menuButtons;

	void Start()
	{
		switch (ProgressManager.level)
		{
		case 1 : menuButtons[0].GetComponent<MenuButton>().SetDimension(Dimension.Present);
			menuButtons[1].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			menuButtons[2].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			menuButtons[3].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			menuButtons[4].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			menuButtons[5].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			break;
		
		case 2 : menuButtons[0].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[1].GetComponent<MenuButton>().SetDimension(Dimension.Present);
			menuButtons[2].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			menuButtons[3].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			menuButtons[4].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			menuButtons[5].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			break;

		case 3 : menuButtons[0].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[1].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[2].GetComponent<MenuButton>().SetDimension(Dimension.Present);
			menuButtons[3].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			menuButtons[4].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			menuButtons[5].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			break;

		case 4 : menuButtons[0].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[1].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[2].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[3].GetComponent<MenuButton>().SetDimension(Dimension.Present);
			menuButtons[4].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			menuButtons[5].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			break;

		case 5 : menuButtons[0].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[1].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[2].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[3].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[4].GetComponent<MenuButton>().SetDimension(Dimension.Present);
			menuButtons[5].GetComponent<MenuButton>().SetDimension(Dimension.Future);
			break;

		case 6 : menuButtons[0].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[1].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[2].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[3].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[4].GetComponent<MenuButton>().SetDimension(Dimension.Past);
			menuButtons[5].GetComponent<MenuButton>().SetDimension(Dimension.Present);
			break;
			//case 1 : set buttons greater than to future and 1 to present and before to past

		}
	}
}
