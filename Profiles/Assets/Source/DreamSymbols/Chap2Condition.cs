using UnityEngine;
using System.Collections;

public class Chap2Condition : MonoBehaviour {

	public Animator jacket, camerax;
	public GameObject pink1, pink2;
	bool isPinkReadytoHoldHand;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
		{
			if (jacket.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Clickable"))
			{
				//set camera movement animation
				camerax.SetTrigger("Pan");
			}
		}

	}
}
