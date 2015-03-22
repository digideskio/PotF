using UnityEngine;
using System.Collections;

public class Chap2Condition : MonoBehaviour {

	public Animator jacket, camerax;
	bool isPinkReadytoHoldHand;
	public GameObject walkie;
	public Animator BG, pink, jason;
	public static Chap2Condition s_instance;
	// Use this for initialization
	void Awake () {
		s_instance = this;
	}

	void Start(){
		SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.water);
		SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.nightAmbience);
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

	public void TriggerWalkie()
	{
		walkie.GetComponentInChildren<WalkieHandler> ().StartWalkie ();
		BG.SetTrigger ("fadeOut");
		pink.SetTrigger ("fadeOut");
		jason.SetTrigger ("fadeOut");
	}
}
