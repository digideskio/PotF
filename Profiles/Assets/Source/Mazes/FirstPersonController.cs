﻿using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 2.0f;
	public float upDownRange = 60.0f;
	public float verticalRotation = 0.0f;
	public AudioSource[] footSteps;
	AudioSource currentFootstep = null;
	int upperMax;
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {

		//rotation
		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity; //retrieve lateral mouse movement
		transform.Rotate (0, rotLeftRight, 0);

		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity; //retrieve vertical mouse movement
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange); //do not let vertical movement beyond range

		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0); //move the camera (instead of controller) vertically 

		//movement

		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed; //request speed from input which is already mapped to asdw
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed; //request speed from input which is already mapped to asdw

		if (Input.GetMouseButton (0))
			forwardSpeed = movementSpeed;
		else if (Input.GetMouseButton (1))
			forwardSpeed = -movementSpeed;
		
		Vector3 speed = new Vector3 (sideSpeed, 0, forwardSpeed); //create a direction vector from forwardSpeed

		speed = transform.rotation * speed; //changes the vector direction of speed to match rotation direction

		CharacterController cc = GetComponent<CharacterController> (); //find character controller

		cc.SimpleMove (speed); //move controller
		if (forwardSpeed != 0 || sideSpeed != 0)
						PlayFootStep ();
		if (forwardSpeed == 0 && sideSpeed == 0 && currentFootstep != null)
						StartCoroutine ("CeaseFootstep");
	
	}

	void PlayFootStep(){
		if (currentFootstep == null) {
			upperMax = footSteps.Length;
			int footStepIndex = Random.Range (0, upperMax);
			currentFootstep = footSteps [footStepIndex];
			currentFootstep.volume = 0.5f;
			currentFootstep.Play ();
			//a timer could work starttime = Time.time, a counter is always counting in update, a bool is set for footstep playing, and it goes off after timer catches up to timeTilFootstep can play
			//I use coroutine instead
			StartCoroutine("NullifyFootstep");
		}
	}

	IEnumerator NullifyFootstep() {
		yield return new WaitForSeconds (.5f);
		currentFootstep = null;
	}

	IEnumerator CeaseFootstep() {
		while (currentFootstep!=null && currentFootstep.volume > 0.0f) {					//where x is sound track file
		currentFootstep.volume -= 0.1f;
		yield return new WaitForSeconds (0.15f);
		}
	}




}
