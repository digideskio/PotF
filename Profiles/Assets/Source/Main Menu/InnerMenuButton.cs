using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum LevelType {Maze, Chat, AutoSymbolism, Flashback, Video};


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

	void Start() {
		onHover = GameObject.Find ("onHover").GetComponent<AudioSource> ();
		onClick = GameObject.Find ("onLoad").GetComponent<AudioSource> ();

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
			switch (GameManager.s_instance.subLevel) {
			case 1 : SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.melancholy);break;
			case 2 : SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.drowning);break;
			case 3 : SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.ambient);break;
			case 4 : SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.melancholy);break;
			case 5 : SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.jacob);break;
			case 6 : SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.ambient);break;
			case 7 : SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.drowning);break;
			case 8 : SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.ambient);break;
			case 9 : SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.ambient);break;
			case 10 : SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.melancholy);break;
			case 11 : SoundtrackManager.s_instance.StartCoroutine("FadeOutAudioSource",SoundtrackManager.s_instance.ambient);break;
			}
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
