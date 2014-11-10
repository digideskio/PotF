using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkingCursor : MonoBehaviour {      
	
	private float m_TimeStamp;
	private bool cursor = false;
	public Text submissionText;

	public void AddWord(string word) {
		if (cursor == false)
			submissionText.text = word + " ";
		else
			submissionText.text = word + "_";

	}

	void Update() {
		if (Time.time - m_TimeStamp >= 0.5)
		{
			m_TimeStamp = Time.time;
			if (cursor == false)
			{
				cursor = true;
				if (submissionText.text.Length != 0)
				{
					submissionText.text = submissionText.text.Substring(0, submissionText.text.Length - 1);
				}
				submissionText.text = submissionText.text.Insert(submissionText.text.Length, "_");
			}

			else
			{
				cursor = false;
				if (submissionText.text.Length != 0)
				{
					submissionText.text = submissionText.text.Substring(0, submissionText.text.Length - 1);
					submissionText.text = submissionText.text.Insert(submissionText.text.Length, " ");
				}
			}
		}
	}
}