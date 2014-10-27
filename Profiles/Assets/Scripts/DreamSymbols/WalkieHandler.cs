using UnityEngine;
using System.Collections;

public class WalkieHandler : MonoBehaviour {

	public Animator self;
	public AudioSource VO;

	bool isPlaying;
	// Update is called once per frame
	void Update ()
	{
		if (self.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.playing"))
	    {
			if (isPlaying)
			{
				if (VO.isPlaying == false)
				{
//					Application.LoadLevel
				}
			}
		}
	}

	public void StartWalkie ()
	{
		self.SetTrigger ("paddleOver");
	}

	void OnMouseDown()
	{
		if (self.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.onScreen	"))
		{
			self.SetTrigger ("Click");
			VO.Play ();
			isPlaying = true;
			gameObject.GetComponentInParent<ImageDrift>().shakeAmount = 1;
		}
	}
}
