using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[Serializable]
public struct PossibleLines
{
    public PossibleLines(int _speaker, string _line)
    {
        speaker = _speaker;
        line = _line;
    }
    public int speaker;
    public string line;
}

public class Dialogue : MonoBehaviour
{
    SpriteRenderer headShotSprite;

    Sprite[] availableHeadshots;

    public TextMeshProUGUI textToBeEdited;

    PossibleLines[] currentConversation;
    int currentSentenceIndex;
    string currentSentence;
    int currentSentenceNumber;

    bool sentenceRead;

    public float textMoveDelay;
    float timer;

    //function for starting a new string, with fitting string and headshot
    public void InitiateNewConversation(PossibleLines[] newConversation)
    {
        currentConversation = newConversation;
        currentSentence = newConversation[0].line;
        currentSentenceIndex = 0;
        sentenceRead = false;
        ChangeHeadshot(newConversation[0].speaker);
    }

    //function to let the text appear letter for letter
    public void MoveText()
    {
        if(!sentenceRead)
        {
            if (timer <= 0)
            {
                sentenceRead = !ReadOutText();
                timer = textMoveDelay;
            }

            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    //Optional function for the player to skip the movement of the dialogue
    public void SkipText()
    {
        currentSentenceNumber = currentSentence.Length;
    }

    public void ContinueText()
    {
        if(currentSentenceIndex >= currentConversation.Length)
        {
            EndConversation();
        }

        else
        {
            currentSentenceIndex++;
            currentSentence = currentConversation[currentSentenceIndex].line;
            sentenceRead = false;
            ChangeHeadshot(currentConversation[currentSentenceIndex].speaker);
        }
    }

    void ChangeHeadshot(int headshotIndex)
    {
        Sprite headShotImage = null;
        if (availableHeadshots[headshotIndex] != null)
            headShotImage = availableHeadshots[headshotIndex];

        if(headShotImage != null)
        {
            headShotSprite.sprite = headShotImage;
        }
    }

    //Function to end the conversation, Returning the player to the usual gameplay
    void EndConversation()
    {
        currentConversation = null;
    }

    bool ReadOutText()
    {
        char[] fullSentence;
        fullSentence = currentSentence.ToCharArray();

        Debug.Log(currentSentenceNumber);
        char[] partOfTheSentence = new char[currentSentenceNumber + 1];
        for (int i = 0; i <= currentSentenceNumber; i++)
        {
            partOfTheSentence[i] = fullSentence[i];
        }

        string newText = new string(partOfTheSentence);
        Debug.Log(newText);
        textToBeEdited.text = newText;

        currentSentenceNumber++;

        if (currentSentenceNumber > partOfTheSentence.Length)
        {
            currentSentenceNumber = 0;
        }

        if (currentSentenceNumber >= fullSentence.Length)
        {
            currentSentenceNumber = 0;
            return false;
        }

        return true;
    }
}
