using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChatPlayer : MonoBehaviour { //handles timer and delays + progress through texts

	public Dialogue dialogueFile; //holds all of the text and character information for a conversation
	int progressCounter = 0; //keeps track of how far along we are in the conversation
	public int delayRangeMin, delayRangeMax, userResponseDelay; //sets time in seconds of rhythm of conversation
	Characters currentCharacter; //character enum used to identify whom with the user is talking and how to print the text
	string submittedWords = ""; //a place holder for the sentences that the user is creating
	public Text submissionSentence; //text that displays submittedWords
	public Text[] displayedSentences = new Text[6]; //UI objects holding the sentences
	GUIStyle style = new GUIStyle(); //allows text to be displayed with HTML formatting
	public List<string> dialogueTexts; //holds the strings that display conversation
	public Button submit, reset;

	void Start () {
		currentCharacter = dialogueFile.DialogItems [0].character; //sets conversation with character listed in the first element of dialogue
		style.richText = true; //allows html modifications to text
		StepsisterCycle (); //kicks off the conversation
	}

	void NextDialogueItem () //progresses forward to the next element in the Dialogue
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
			StartCoroutine ("SisterDelay");
		else
			UserCycle ();
	}

	void UserCycle()
	{
		if (dialogueFile.DialogItems[progressCounter].wordChoices != null)
			StartCoroutine ("UserDelay");
		else
			NextDialogueItem();
	}

	IEnumerator SisterDelay()
	{
		//Pause for a random amount of time and then display sister's sentence
		int delayInt = Random.Range (delayRangeMin, delayRangeMax);
		yield return new WaitForSeconds (delayInt);
		DisplayCharacterSentence (dialogueFile.DialogItems [progressCounter].characterSentence, currentCharacter);
		UserCycle ();
	}
	

	IEnumerator UserDelay()
	{
		yield return new WaitForSeconds (userResponseDelay);
		//activate the button layout
		GetComponent<ButtonLayout> ().Activate (dialogueFile.DialogItems [progressCounter].wordChoices);

	}

	//close the chat sequence
	void EndChatSequence () {;}
	
	public void DisplayCharacterSentence(string characterInput, Characters character)
	{
		switch (character) //depending on which character the string belongs to, displays a different style of text
		{
		case Characters.User : AddToDialogue ("<color=#6FFF47> Jason: </color>" + characterInput); break;
		case Characters.Stepsister : AddToDialogue ( "<color=#CB2EFF> Stepsister: </color>" + characterInput); break;
		case Characters.Pink : AddToDialogue ( "<color=#CB2EFF> Pink: </color>" + characterInput); break;
		}
	}
	
	void AddToDialogue(string sentenceText) //places sentences of a conversations in chronilogical order
	{
		if (dialogueTexts.Count < 6)
		{
			dialogueTexts.Add(sentenceText); //adds new dialogue to chat area while it still isnt full
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
		if (dialogueTexts.Count > 0) //if either the user or another character has submitted a sentence
		{
			for (int i = 0; i < dialogueTexts.Count; i++) // 
			{
				displayedSentences[i].text = dialogueTexts[i];
				displayedSentences[i].rectTransform.anchoredPosition = new Vector2 (0.1f, (220.0f - (float)i * 60.0f));
			}
		}	
	}
	
	//The Following handles the accumulated sentence
	
	public void AddWord(string word)
	{
		submittedWords += word;
		submissionSentence.text = submittedWords;
		//change reset state to on
		reset.interactable = true;
		if (IsProperSentence (submittedWords))
			//change submit state to active
			submit.interactable = true;
		else 
			//change submit state to inactive
			submit.interactable = false;
	}

	public void Submit()
	{
		DisplayCharacterSentence (submittedWords, Characters.User); //put sentence in display area
		submittedWords = "";
		//set submit to inactive
		submit.interactable = false;
	}

	public void Reset()
	{
		submittedWords = "";
		submissionSentence.text = submittedWords;
		if (submittedWords != "") 
			GetComponent<ButtonLayout> ().Activate (dialogueFile.DialogItems [progressCounter].wordChoices); //fill buttons with text and ma them visible
		reset.interactable = false; //change reset state inactive


	}
	
	public bool IsProperSentence(string userAnswer) //checks to see if user has constructed valid sentence
	{
		for (int i = 0; i < dialogueFile.DialogItems[progressCounter].correctAnswers.Count; i++)
		{
			if (userAnswer == dialogueFile.DialogItems[progressCounter].correctAnswers[i])
			{
				return true;
			}
		}
		return false;
	}

}
