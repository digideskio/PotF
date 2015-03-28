using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public bool inWater = false;
	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 2.0f;
	public float upDownRange = 60.0f;
	public float verticalRotation = 0.0f;
	public AudioSource[] footSteps;
	AudioSource currentFootstep = null;
	int upperMax;
	float cooldown = .5f, fadeSpeed = 0.15f;
	// Use this for initialization
	void Start () {
		StartCoroutine ("CleanUp");
		Screen.lockCursor = true;
		if (inWater) {
			cooldown = .5f;
			movementSpeed = 3.0f;
		}

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
			currentFootstep = (AudioSource)Instantiate(footSteps [footStepIndex]);
			currentFootstep.tag = "foot";
			currentFootstep.volume = 0.5f;
			currentFootstep.Play ();
			//a timer could work starttime = Time.time, a counter is always counting in update, a bool is set for footstep playing, and it goes off after timer catches up to timeTilFootstep can play
			//I use coroutine instead
			StartCoroutine("NullifyFootstep");
		}
	}

	IEnumerator NullifyFootstep() {
		yield return new WaitForSeconds (cooldown);
		Destroy (currentFootstep);
	}

	IEnumerator CeaseFootstep() {
		if (!inWater) {
			while (currentFootstep!=null && currentFootstep.volume > 0.0f) {					//where x is sound track file
				currentFootstep.volume -= 0.1f;
				yield return new WaitForSeconds (fadeSpeed);
			}
		}
	}

	IEnumerator CleanUp(){
		while (true) {
			yield return new WaitForSeconds(4);
			GameObject[] footsteps = GameObject.FindGameObjectsWithTag("foot");
			foreach (GameObject f in footsteps)
				Destroy(f);
		
		}
	}




}
