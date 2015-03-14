using UnityEngine;
using System.Collections;

public class WalkieHandler : MonoBehaviour {

	public Animator self;
	public AudioSource VO;


	bool isPlaying, isActive;
	// Update is called once per frame
	void Update ()
	{

			if (isPlaying)
			{
				if (VO.isPlaying == false)
				{
					SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.water);		
					GameManager.s_instance.isAutoSymbolismComplete = true;
					Application.LoadLevel(GameManager.s_instance.subLevel.ToString());
				}
			}
		}

	public void StartWalkie ()
	{
		self.SetTrigger ("paddleOver");
		isActive = true;
	}

	void OnMouseDown()
	{
		if (isActive)
		{
			isActive = false;
			print ("click");
			self.SetTrigger ("Click");
			VO.Play ();
			isPlaying = true;
			gameObject.GetComponentInParent<ImageDrift>().shakeAmount = 1;
		}
	}
}
