using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueDisplayer : MonoBehaviour {

	string submittedWords = "";
	public Text sentence;
	GUIStyle style = new GUIStyle();
	List<string> dialogueTexts = new List<string>(); 

	void Start ()
	{
		style.richText = true; //allows html modifications to text
	}
	

	public void displayCharacterSentence(string characterInput, Characters character)
	{
		switch (character)
		{
			case Characters.User : addToDialogue ("<color=#6FFF47> Jason: </color>" + characterInput); break;
			case Characters.Stepsister : addToDialogue ( "<color=#CB2EFF> Stepsister: </color>" + characterInput); break;
			case Characters.Pink : addToDialogue ( "<color=#CB2EFF> Pink: </color>" + characterInput); break;
		}
	}

	void addToDialogue(string sentenceText)
	{

		if (dialogueTexts.Count < 6)
		{
			print ("count < 6");
			dialogueTexts.Add(sentenceText); //adds new dialogue to chat area while it still isnt full
			print (dialogueTexts[0]);
		}
		
		else

		{
			for (int i = 1; i < 6; i++)
			{
				dialogueTexts[i-1] = dialogueTexts[i];
			}
			dialogueTexts[5] = sentenceText; //moves all text one slide down when it is full
		}
	}

	void Update()
	{
		GameObject bar = GameObject.Find ("submissionBar");
		bar.guiText.text = submittedWords;

		if (dialogueTexts.Count > 0)
		{
				
			for (int i = 1; i < dialogueTexts.Count+1; i++)
			{
				GameObject temp = GameObject.Find("Sent"+i);
				temp.guiText.text = dialogueTexts[i-1];
				temp.transform.position = new Vector3 (0.1f, (1.0f - (float)i * 0.1f),0.0f);
			}
		}	
	}

	//The Following handles the accumulated sentence

	public void addWord(string word)
	{
		submittedWords += word;
	}
	
	public void reset()
	{
		submittedWords = "";
	}
	
	public string returnSubmittedWords()
	{
		return submittedWords;
	}

//		public bool isProperSentence(string userAnswer, )
//		{
//			for (int i = 0; i < answers.Count; i++)
//			{
//				if (answers[i] == userAnswer)
//				{
//					return true;
//				}
//			}
//			return false;
//		}
//}

}
