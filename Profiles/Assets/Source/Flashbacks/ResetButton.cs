using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {

	public Animator one,two,three;
	public AudioSource reset;
	public GameObject button1, button2, button3;

	public void Reset()
	{
		print ("reset");
		one.SetTrigger ("Reset");
		two.SetTrigger ("Reset");
		three.SetTrigger ("Reset");
		reset.Play ();
		FlashBackContainer.ResetFlashbacks ();
		button1.gameObject.GetComponent<ImageController> ().ResetSmallPick ();
		button2.gameObject.GetComponent<ImageController> ().ResetSmallPick ();
		button3.gameObject.GetComponent<ImageController> ().ResetSmallPick ();

	}
}
