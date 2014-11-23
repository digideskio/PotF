using UnityEngine;
using System.Collections;

public class Chap2Condition : MonoBehaviour {

	public Animator jacket, camerax;
	bool isPinkReadytoHoldHand;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
		{
			if (camerax.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Clickable"))
			{
				//set camera movement animation
				camerax.SetTrigger("Pan");
			}
		}

	}
}
