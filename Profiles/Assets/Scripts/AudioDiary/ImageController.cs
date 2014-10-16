using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageController : MonoBehaviour {

	public Animator image;
	public Image imageGO;
	public Canvas parent;

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
		image.SetTrigger ("Click");
		GetComponent<FlashBack> ().AddToFlashBackList ();
	}
}
