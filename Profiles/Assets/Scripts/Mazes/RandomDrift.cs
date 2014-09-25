using UnityEngine;
using System.Collections;

public class RandomDrift : MonoBehaviour {

	float m_TimeStamp;
	public float driftSpeed, randomRange;

	void Update()
	{
	
		float randX = Random.Range(-randomRange, randomRange);
		float randZ = Random.Range(-randomRange, randomRange);
		Quaternion currentRot = transform.rotation;
		Quaternion targetRot = Quaternion.Euler(currentRot.x + randX, currentRot.y, currentRot.z + randZ);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * (1.0f/driftSpeed));

	}
}
