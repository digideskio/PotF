using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiddenText : MonoBehaviour {

	public Animator image, buttonText;
	public AudioSource onHover;
	
	void OnMouseEnter()
	{
		onHover.Play ();
		image.SetTrigger ("Enter");
		image.ResetTrigger ("Exit");
	}
	
	void OnMouseExit()
	{
		image.SetTrigger ("Exit");
		image.ResetTrigger ("Enter");
	}
}
