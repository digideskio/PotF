using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StripTease : MonoBehaviour {

	public Image[] stripMode;
	int i = 0;

	void OnTriggerEnter() {
		if (i < 7) {
			stripMode[i].enabled = false;
			i++;
			stripMode[i].enabled = true;
		}
	}
}
