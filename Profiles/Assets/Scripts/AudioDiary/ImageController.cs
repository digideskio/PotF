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
	}

	void OnMouseExit()
	{
		image.SetTrigger ("Exit");
	}

	void OnMouseDown()
	{
		image.SetTrigger ("Click");
		GetComponent<FlashBack> ().AddToFlashBackList ();
	}
}
