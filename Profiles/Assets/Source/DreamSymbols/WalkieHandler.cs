using UnityEngine;
using System.Collections;

public class WalkieHandler : MonoBehaviour {

	public Animator self;
	public AudioSource VO;


	bool isActive, hasPlayed = false;
	// Update is called once per frame
		


	public void StartWalkie ()
	{
		self.SetTrigger ("paddleOver");
		isActive = true;
	}

	void OnMouseDown()
	{
		if (isActive && hasPlayed == false)
		{
			isActive = false;
			hasPlayed = true;
			self.SetTrigger ("Click");
			VO.volume = .3f;
			VO.Play ();
			gameObject.GetComponentInParent<ImageDrift>().shakeAmount = 1;
			StartCoroutine("EndLevel");
		}
	}

	IEnumerator EndLevel(){
		yield return new WaitForSeconds (VO.clip.length - 4f);
		GameObject.Find ("fadeOut").GetComponent<FadeOut> ().StartFade ();
		SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.water);	
		SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.nightAmbience);	
		SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.insignificance);	

		GameManager.s_instance.isAutoSymbolismComplete = true;
		yield return new WaitForSeconds (3);
		Application.LoadLevel(GameManager.s_instance.subLevel.ToString());
	}
}
