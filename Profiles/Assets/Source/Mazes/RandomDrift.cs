using UnityEngine;
using System.Collections;

public class RandomDrift : MonoBehaviour {

	float m_TimeStamp;
	public float driftSpeed, randomRange;
	bool flowGate = true;

	void Update()
	{
		if (flowGate)
		{
			transform.rotation = Quaternion.Euler(0, transform.rotation.x, transform.rotation.y);
			StartCoroutine ("Shake");
			flowGate = false;

		}
	}

	IEnumerator Shake ()
	{
		float randX = Random.Range(-randomRange, randomRange);
		float randZ = Random.Range(-randomRange, randomRange);
		Quaternion currentRot = transform.rotation;
		Quaternion targetRot = Quaternion.Euler(currentRot.x, currentRot.y + randX, currentRot.z + randZ);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * (1.0f/driftSpeed));
		yield return new WaitForSeconds(0.01f);
		Quaternion rebound = Quaternion.Euler(0, transform.rotation.y + randX, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, rebound, Time.deltaTime * (1.0f/driftSpeed));
		yield return new WaitForSeconds(1.0f/driftSpeed);

		flowGate = true;
	}
}
