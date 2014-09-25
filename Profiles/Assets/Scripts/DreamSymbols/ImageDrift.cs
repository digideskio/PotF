using UnityEngine;
using System.Collections;

public class ImageDrift : MonoBehaviour {

	//This script takes a UI image and shakes it around in 2D directions to make look cool

	public int shakeAmount;
	public float shakeSpeed;

	void Start()
	{
		StartCoroutine ("ShakeImage");
	}

	IEnumerator ShakeImage()
	{
		while (true)
		{
			int xAmount = Random.Range(-shakeAmount, shakeAmount);
			int yAmount = Random.Range(-shakeAmount, shakeAmount);
			gameObject.transform.Translate(new Vector3(xAmount, yAmount, 0), gameObject.transform);
			yield return new WaitForSeconds(shakeSpeed);
			gameObject.transform.Translate(new Vector3(-xAmount, -yAmount, 0), gameObject.transform);
			yield return new WaitForSeconds(shakeSpeed);


		}

	}

}
