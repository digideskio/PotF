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
	public string nextLevel;

	public AudioSource jason, sister, song, logout, login, clickWord, resetButton;

	void Start () {
		currentCharacter = dialogueFile.DialogItems [0].character; //sets conversation with character listed in the first element of dialogue
		style.richText = true; //allows html modifications to text
		StepsisterCycle (); //kicks off the conversation
		if (currentCharacter == Characters.Pink)
			SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.pink);
		else
			SoundtrackManager.s_instance.PlayAudioSource (SoundtrackManager.s_instance.chat);
	}

	void NextDialogueItem () //progresses forward to the next element in the Dialogue
	{
		if (progressCounter < dialogueFile.DialogItems.Count-1)
		{
			progressCounter++;
			StepsisterCycle ();
		}

		else
			StartCoroutine(EndChatSequence());
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
		resetButton.Play ();

	}

	//close the chat sequence
	IEnumerator EndChatSequence ()
	{
		yield return new WaitForSeconds(3.0f);
		if (currentCharacter == Characters.Pink)
			DisplayCharacterSentence ("", Characters.PinkLogOut); //displays that the current character has logged off
		else
			DisplayCharacterSentence ("", Characters.SisterLogOut );
		StartCoroutine (CloseChat());

	}

	IEnumerator CloseChat(){
		//fade out, play a transition sound
		if (currentCharacter == Characters.Pink)
			SoundtrackManager.s_instance.StartCoroutine ("FadeOutAudioSource",SoundtrackManager.s_instance.pink);
		else
			SoundtrackManager.s_instance.StartCoroutine ("FadeOutAudioSource",SoundtrackManager.s_instance.chat);
		yield return new WaitForSeconds(4.0f);
		GameManager.s_instance.isChatComplete = true;
		Application.LoadLevel(GameManager.s_instance.subLevel.ToString());
	}
	
	public void DisplayCharacterSentence(string characterInput, Characters character)
	{
		switch (character) //depending on which character the string belongs to, displays a different style of text
		{
		case Characters.User : AddToDialogue ("<color=#00FF00>Jason: </color>" + characterInput);
			jason.Play ();
			break;
		case Characters.Stepsister : AddToDialogue ( "<color=#9970CB>Stepsister: </color>" + characterInput);
			sister.Play ();
			break;
		case Characters.Pink : AddToDialogue ( "<color=#CB2EFF>Pink: </color>" + characterInput);
			sister.Play ();
			break;
		case Characters.PinkLogOut : AddToDialogue ("<color=#646464>Pink has logged off. </color>");
			logout.Play();
			break;
		case Characters.SisterLogOut : AddToDialogue ("<color=#646464>Stepsister has logged off. </color>" );
			logout.Play();
			break;
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
				displayedSentences[i].rectTransform.anchoredPosition = new Vector2 (0.1f, (240.0f - (float)i * 60.0f));
			}
		}	
	}
	
	//The Following handles the accumulated sentence
	
	public void AddWord(string word)
	{
		clickWord.Play ();
		submittedWords += word; //adds to the string version of the accumulated sentence
		submissionSentence.GetComponent<BlinkingCursor> ().AddWord (submittedWords); //adds to the displayed version which requires a special operator overload for blinking cursor
		//change reset state to on
		reset.gameObject.SetActive (true);
		if (IsProperSentence (submittedWords))
			//change submit state to active
			submit.gameObject.SetActive(true);
		else 
			//change submit state to inactive
			submit.gameObject.SetActive(false);
	}

	public void Submit()
	{
		DisplayCharacterSentence (submittedWords, Characters.User); //put sentence in display area
		submittedWords = "";
		submissionSentence.text = "";
		//set submit to inactive
		submit.gameObject.SetActive (false);
		reset.gameObject.SetActive (false);
		GetComponent<ButtonLayout> ().DeactivateAll ();
		NextDialogueItem ();
	}

	public void Reset()
	{
		submittedWords = "";
		submissionSentence.text = submittedWords;
		GetComponent<ButtonLayout> ().Activate (dialogueFile.DialogItems [progressCounter].wordChoices); //fill buttons with text and ma them visible
		resetButton.Play ();
		reset.gameObject.SetActive (false);	
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
