using UnityEngine;
using System.Collections;

public class SkullClick : MonoBehaviour
{
	public ProfileList profiles;
	void Start()
	{
		//finds the bar of profiles choices
		profiles = GameObject.Find("ProfileList").GetComponent<ProfileList>();

	}
	void OnMouseDown () {
		//if bottom skull is clicked
		if (gameObject.name == ("skullDownBox")){
			//move bar up one notch
			print ("Clicked DOWN");
			profiles.MoveUp();

		}
		//if top skull is clicked
		if (gameObject.name == ("skullUpBox")){
			//move bar up one notch
			print ("Clicked UP");
			profiles.MoveDown();
		}
	}
	void OnMouseUp () {
	}
}
