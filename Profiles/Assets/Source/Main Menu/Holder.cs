using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Holder : MonoBehaviour {

	public Image placeHolderSprite;
	public Sprite temp;
	// Use this for initialization
	void Start () {
		placeHolderSprite = GetComponent<Image> ();
		temp = Resources.Load ("Art/MainMenu/ButtonSmall", typeof(Sprite)) as Sprite;
		placeHolderSprite.sprite = temp;
	}

}
