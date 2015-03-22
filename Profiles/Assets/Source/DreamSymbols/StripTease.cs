using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StripTease : MonoBehaviour {

	public GameObject bat;
	public GameObject walkie;
	public Animator BG;

	public GameObject[] stripMode;
	int i = 0;

	void Start(){
		SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.water);
		SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.nightAmbience);
		SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.insignificance);
	}

	void OnMouseDown() {
		if (i < 6) {
			stripMode[i].SetActive(false);
			i++;
			print (i);
			stripMode[i].SetActive(true);
			if (i < 6) {
				GameObject.Find("cL").GetComponent<AudioSource>().Play();
			}
			else 
				GameObject.Find("cZ").GetComponent<AudioSource>().Play();
		}
		else if (i == 6) {
			bat.GetComponent<Animator>().SetTrigger("Thrust");
			StartCoroutine("EnableWalkie");
			GameObject.Find("thrust").GetComponent<AudioSource>().Play();
			GameObject.Find("slut").GetComponent<AudioSource>().Play();


		}
	}

	IEnumerator EnableWalkie() {
		yield return new WaitForSeconds (8);
		walkie.GetComponentInChildren<WalkieHandler> ().StartWalkie ();
		BG.SetTrigger ("fadeOut");
		bat.GetComponent<Animator>().SetTrigger("fadeout");
		bat.GetComponent<Animator>().SetTrigger("fadeout");


	}
}
