using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Characters {User, Stepsister, Pink, SisterLogOut, PinkLogOut};

[System.Serializable]
public class DialogueElement
{
	public Characters character; //in case certain characters want to say something in more than one sentence
	public List<string> wordChoices; //words that appear in buttons allowing the user to form a sentence
	public List<string> correctAnswers; //list of sentences that are appropiate formations of wordChoices
	public string characterSentence; //scripted response to user submission
}
