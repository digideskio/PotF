using UnityEngine;
using System.Collections;

public class TimeModifier : MonoBehaviour {
	public float StartTime;
	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().time = StartTime;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
