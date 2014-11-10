using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class OnClick : MonoBehaviour {

	public Canvas parent;
	public void SendWord() {
		string buttonText = GetComponentInChildren<Text> ().text;
		print ("sending");
		GetComponentInParent<ChatPlayer> ().AddWord (buttonText);
		gameObject.SetActive (false);
	}
	
}
