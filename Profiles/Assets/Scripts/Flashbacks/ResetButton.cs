using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {

	public Animator one,two,three;
	public AudioSource reset;

	public void Reset()
	{
		print ("reset");
		one.SetTrigger ("Reset");
		two.SetTrigger ("Reset");
		three.SetTrigger ("Reset");
		reset.Play ();
		FlashBackContainer.ResetFlashbacks ();
	}
}
