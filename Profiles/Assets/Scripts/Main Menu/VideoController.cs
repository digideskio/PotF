using UnityEngine;
using System.Collections;


public class VideoController : MonoBehaviour {

	//Assign Class Variable
	public MovieTexture movie;

	//Initialize
	void Start () {
		//set the video as the class variable
		movie = renderer.material.mainTexture as MovieTexture;
		//play the video
		movie.Play ();
	}
	
//	 Update is called once per frame
	void Update () {
		//if the movie is done playing
		if (movie.isPlaying == false)
		
		{
			//load login screen
			Application.LoadLevel("login_scn");
		}
	}
}

