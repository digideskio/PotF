using UnityEngine;
using System.Collections;

public class RandomDrift : MonoBehaviour {

	public float driftSpeed, randomRange;
	bool flowGate = true;

	void Update()
	{
		if (flowGate)
		{
			StartCoroutine ("Shake");
			flowGate = false;

		}
	}

	IEnumerator Shake ()
	{
		/*
		The problem with our shake is that it is randomly drifting such that the character over a long time is facing the wrong direction.
		To remedy this I will first try using rotate fnc. If that does not work, I will try to conceive of a more complex system that ensures to not move the character more than 
		a certain amount of degrees in one direction without going back in the other direction, we could do this my 

		*/

		float randX = Random.Range(-randomRange, randomRange);
		float randZ = Random.Range(-randomRange, randomRange);
//		Quaternion currentRot = transform.rotation;
//		Quaternion targetRot = Quaternion.Euler(currentRot.x, currentRot.y + randX, currentRot.z + randZ);
//		transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * (1.0f/driftSpeed));
//		yield return new WaitForSeconds(0.01f);
//		Quaternion rebound = Quaternion.Euler(0, transform.rotation.y + randX, 0);
//		transform.rotation = Quaternion.Slerp(transform.rotation, rebound, Time.deltaTime * (1.0f/driftSpeed));
//		yield return new WaitForSeconds(1.0f/driftSpeed);
		transform.Rotate(Vector3.down, randX);
		transform.Rotate(Vector3.left, randZ);
		yield return new WaitForSeconds (0.01f);

		flowGate = true;
	}
}
