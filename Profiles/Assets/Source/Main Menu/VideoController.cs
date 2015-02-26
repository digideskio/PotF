using UnityEngine;
using System.Collections;


public class VideoController : MonoBehaviour {

	//Assign Class Variable
	public MovieTexture[] movies;

	//Initialize
	void Start () {
		//set the video as the class variable
		movies[GameManager.s_instance.subLevel] = renderer.material.mainTexture as MovieTexture;
		//play the video
		movies[GameManager.s_instance.subLevel].Play ();
	}
	
//	 Update is called once per frame
	void Update () {
		//if the movie is done playing
		if (movies[GameManager.s_instance.subLevel].isPlaying == false)
		
		{
			//load login screen
			GameManager.s_instance.subLevel++;
			Application.LoadLevel(GameManager.s_instance.subLevel);
		}
	}
}

