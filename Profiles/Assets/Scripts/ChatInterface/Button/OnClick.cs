using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class OnClick : MonoBehaviour {

	public Canvas parent;
	public void SendWord() {
		string buttonText = GetComponentInChildren<Text> ().text;
		print ("sending");
		if (GetComponentInParent<ChatPlayer> ()!=null); //access the buttonLayout canvas and calls the AddWord on its ChatPlayer script
			GetComponentInParent<ChatPlayer> ().AddWord (buttonText);
	}
}
