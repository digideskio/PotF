using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatPlayer : MonoBehaviour { //handles timer and delays + progress through texts

	public Dialogue dialogueFile;
	int progressCounter = 0;
	public int delayRangeMin, delayRangeMax, userResponseDelay;
	DialogueDisplayer dialogueDisplayer;
	Characters currentCharacter;

	//this should be rewritten such that there is more flexibility in terms of progress

	void Start () {
		StepsisterCycle ();
		dialogueDisplayer = gameObject.GetComponent<DialogueDisplayer> ();
		currentCharacter = dialogueFile.DialogItems [0].character; //sets conversation with character listed in the first element of dialogue
	}

	void NextDialogueItem ()
	{
		if (progressCounter < dialogueFile.DialogItems.Count)
		{
			progressCounter++;
			StepsisterCycle ();
		}

		else
			EndChatSequence();
	}


	void StepsisterCycle() //sets the chat in motion, goes through sister first and then user/Jason
	{
		if (dialogueFile.DialogItems [progressCounter].characterSentence != null)
			StartCoroutine ("sisterDelay");
		else
			UserCycle ();
	}

	void UserCycle()
	{
		if (dialogueFile.DialogItems[progressCounter].wordChoices != null)
			StartCoroutine ("userDelay");
		else
			NextDialogueItem();
	}

	IEnumerator SisterDelay()
	{
		//Pause for a random amount of time and then display sister's sentence
		int delayInt = Random.Range (delayRangeMin, delayRangeMax);
		yield return new WaitForSeconds (delayInt);
		UserCycle ();
	}
	

	IEnumerator UserDelay()
	{
		yield return new WaitForSeconds (userResponseDelay);
		progressCounter++;
		//display the new list of buttons, wait til proper submission, get next item
		
		NextDialogueItem ();
	}

	void EndChatSequence () {;}

	public int ReturnProgCounter()
	{
		return progressCounter;
	}
}
