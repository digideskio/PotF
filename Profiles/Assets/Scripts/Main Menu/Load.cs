using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Load : MonoBehaviour {

	public Animator image, buttonText;
	public Image imageGO;
	public AudioSource onHover, onClick;
	public List<GameObject> ParentOfButtons;

	void OnMouseEnter()
	{
		image.SetTrigger ("Enter");
		image.ResetTrigger ("Exit");
		onHover.Play ();

	}
	
	void OnMouseExit()
	{
		image.SetTrigger ("Exit");
		image.ResetTrigger ("Enter");

	}
	
	void OnMouseDown()
	{
		if (image.GetCurrentAnimatorStateInfo(0).IsName("Highlighted"))
		{
			print ("clicked");
			image.SetTrigger ("Click");
			onClick.Play ();
			foreach (GameObject go in ParentOfButtons)
				go.SetActive(true);
		}
	}
}
