using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum LevelType {Maze, Chat, AutoSymbolism, Flashback};


//handles the actual loading of Levels like maze1, chat1, etc etc etc also lets GameManager when level is played

public class InnerMenuButton : MonoBehaviour {

	public LevelType levelType;
	public string levelName;
	public Animator image, buttonText;
	public Image imageGO;
	public AudioSource onHover, onClick;

	void Awake ()
	{
		Image buttonPNG = GetComponentInParent<Image> ();
		buttonPNG.sprite = Resources.Load ("Art/MainMenu/ButtonSmall", typeof(Sprite)) as Sprite;
	}

	void OnMouseEnter()
	{
		onHover.Play ();
		image.SetTrigger ("Enter");
		image.ResetTrigger ("Exit");
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
			GameManager.s_instance.MarkAsComplete(levelType);
			StartCoroutine(LoadLevel());
		}
	}

	IEnumerator LoadLevel ()
	{
		yield return new WaitForSeconds (1);
		Application.LoadLevel (levelName);
	}
}
