using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageController : MonoBehaviour {

	public Animator image;
	public Image imageGO, smallPicture;
	public Canvas parent;
	public AudioSource diaryBit, onClick;
	bool hasSmallPicBeenClicked = false;

	public void ResetSmallPick () 
	{
		smallPicture.gameObject.SetActive (true);
		hasSmallPicBeenClicked = false;

	}

	void OnMouseEnter()
	{
		if (image.GetCurrentAnimatorStateInfo(0).IsName("Static"))
			diaryBit.Play ();
		image.SetTrigger ("Enter");
		image.ResetTrigger ("Exit");
		if (hasSmallPicBeenClicked == false)
			smallPicture.gameObject.SetActive (false);
	}

	void OnMouseExit()
	{
		image.SetTrigger ("Exit");
		image.ResetTrigger ("Enter");
		if (hasSmallPicBeenClicked == false)
			smallPicture.gameObject.SetActive (true);

	}

	void OnMouseDown()
	{
		if (FlashBackContainer.flashBackList.Contains(GetComponent<FlashBack> ().flashBack) == false)
		{
			if (image.GetCurrentAnimatorStateInfo(0).IsName("Hover"))
			{
				image.SetTrigger ("Click");
				onClick.Play ();
			}
			smallPicture.gameObject.SetActive(false);
			hasSmallPicBeenClicked = true;
			GetComponent<FlashBack> ().AddToFlashBackList ();
		}

	}
}
