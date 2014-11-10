using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartNew : MonoBehaviour {

	public Animator image, buttonText;
	public Image imageGO;
	public AudioSource onHover, onClick;
	public string levelName;

	void OnMouseEnter()
	{
		image.SetTrigger ("Enter");
		image.ResetTrigger ("Exit");
		onHover.Play ();
	}
	
	void OnMouseExit()
	{
		image.SetTrigger ("Exit");
		image.ResetTrigger ("Enter");
	}
	
	void OnMouseDown()
	{
		if (image.GetCurrentAnimatorStateInfo(0).IsName("Highlighted"))
		{
			image.SetTrigger ("Click");
			onClick.Play ();
			GameObject.FindGameObjectWithTag("Fader").GetComponent<Animator>().SetTrigger("Fade");			
			StartCoroutine(LoadLevel());
		}
	}

	IEnumerator LoadLevel()
	{
		yield return new WaitForSeconds (1);
		Application.LoadLevel (levelName);
	}
}
