using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum Dimension {Present, Past, Future};

public class MenuButton : MonoBehaviour {

	public Dimension dimension;
	public Animator image;
	public Image imageGO;
	public AudioSource onHover, onClick;
	public Animator presentText, pastText, futureText;
	public string levelName;

	void OnMouseEnter()
	{
		image.SetTrigger ("Enter");
		image.ResetTrigger ("Exit");
		onHover.Play ();

		switch (dimension)
		{
		case Dimension.Future : futureText.SetTrigger ("Enter"); futureText.ResetTrigger("Exit"); break;
		case Dimension.Past : pastText.SetTrigger ("Enter"); pastText.ResetTrigger("Exit"); break;
		case Dimension.Present : presentText.SetTrigger ("Enter"); presentText.ResetTrigger("Exit"); break;
		}
	}
	
	void OnMouseExit()
	{
		image.SetTrigger ("Exit");
		image.ResetTrigger ("Enter");
		switch (dimension)
		{
		case Dimension.Future : futureText.SetTrigger ("Exit"); futureText.ResetTrigger("Enter"); break;
		case Dimension.Past : pastText.SetTrigger ("Exit"); pastText.ResetTrigger("Enter"); break;
		case Dimension.Present : presentText.SetTrigger ("Exit"); presentText.ResetTrigger("Enter"); break;
		}
	}
	
	void OnMouseDown()
	{
		if (image.GetCurrentAnimatorStateInfo(0).IsName("Highlighted"))
		{
			if (dimension == Dimension.Present)
			{
				image.SetTrigger ("Click");
				GameObject.FindGameObjectWithTag("Fader").GetComponent<Animator>().SetTrigger("Fade");			
				StartCoroutine(LoadLevel());
				onClick.Play ();
			}
		}
	}
	
	IEnumerator LoadLevel()
	{
		yield return new WaitForSeconds (1);
		Application.LoadLevel (levelName);
	}
}
