using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InnerMenuButton : MonoBehaviour {

	public Animator image, buttonText;
	public Image imageGO;
	public AudioSource onHover, onClick;

	void OnMouseEnter()
	{
		image.SetTrigger ("Enter");
		image.ResetTrigger ("Exit");
	}
	
	void OnMouseExit()
	{
		image.SetTrigger ("Exit");
		image.ResetTrigger ("Enter");
	}
	
	void OnMouseDown()
	{
		if (image.GetCurrentAnimatorStateInfo(0).IsName("Hover"))
		{
			image.SetTrigger ("Click");
			onClick.Play ();
		}
	}
}
