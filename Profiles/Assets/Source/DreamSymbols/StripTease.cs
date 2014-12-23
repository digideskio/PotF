using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StripTease : MonoBehaviour {

	public GameObject bat;
	public GameObject walkie;
	public Animator BG;

	public GameObject[] stripMode;
	int i = 0;

	void OnMouseDown() {
		if (i < 6) {
			stripMode[i].SetActive(false);
			i++;
			print (i);
			stripMode[i].SetActive(true);
		}
		else if (i == 6) {
			bat.GetComponent<Animator>().SetTrigger("Thrust");
			StartCoroutine("EnableWalkie");
		}
	}

	IEnumerator EnableWalkie() {
		yield return new WaitForSeconds (7);
		walkie.GetComponentInChildren<WalkieHandler> ().StartWalkie ();
		BG.SetTrigger ("fadeOut");
		bat.GetComponent<Animator>().SetTrigger("fadeout");
		bat.GetComponent<Animator>().SetTrigger("fadeout");


	}
}
