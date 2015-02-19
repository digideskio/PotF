using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Help : MonoBehaviour {
	
	public Text helpInfo;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("h"))
		{
			helpInfo.gameObject.SetActive (!helpInfo.gameObject.activeSelf);
		}
	}

}
