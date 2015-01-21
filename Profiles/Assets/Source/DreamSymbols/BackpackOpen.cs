using UnityEngine;
using System.Collections;

public class BackpackOpen : MonoBehaviour {

	public GameObject backpack1, backpack2, pink;

	bool hasOpenedBackpack = false;
	void OnMouseDown() {
		if (!hasOpenedBackpack) {
			hasOpenedBackpack = true;
			backpack1.SetActive (false);
			backpack2.SetActive (true);
		}

		else {
			pink.SetActive(true);
			pink.GetComponent<Animator>().SetTrigger("fadein");
			backpack2.GetComponent<Animator>().SetTrigger("fadeout");
		}
	}

}
