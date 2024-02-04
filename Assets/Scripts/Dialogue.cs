using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

[Serializable]
public struct Conversation
{
    public Conversation(PossibleLines[] _lines, GameObject[] _activation, GameObject[] _deActivation)
    {
        lines = _lines;
        activation = _activation;
        deActivation = _deActivation;
    }

    public GameObject[] activation;
    public GameObject[] deActivation;
    public PossibleLines[] lines;
}

public class Dialogue : MonoBehaviour
{
    public RawImage headShotSprite;

    public AudioSource playingClip;
    public Texture[] availableHeadshots;
    public AudioClip[] availableClips;

    public TextMeshProUGUI textToBeEdited;

    Conversation convo;
    PossibleLines[] currentConversation;
    int currentSentenceIndex;
    string currentSentence;
    int currentSentenceNumber;

    bool sentenceRead;

    public float textMoveDelay;
    float timer;

    public GameObject ConversationParent;

    public GameObject[] allInteractibles;
    Player player;

    int deathTimer;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    //function for starting a new string, with fitting string and headshot
    public void InitiateNewConversation(Conversation newConversation)
    {
        convo = newConversation;
        currentConversation = newConversation.lines;
        currentSentence = newConversation.lines[0].line;
        currentSentenceIndex = 0;
        sentenceRead = false;
        ChangeHeadshot(newConversation.lines[0].speaker);
        player.reading = true;
    }

    //function to let the text appear letter for letter
    public void MoveText()
    {
        if(!sentenceRead && currentConversation != null)
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

        if(currentConversation == null && ConversationParent.activeSelf)
        {
            textToBeEdited.text = "";
            ConversationParent.SetActive(false);
        }

        else if(currentConversation != null && !ConversationParent.activeSelf)
        {
            ConversationParent.SetActive(true);
        }
    }

    //Optional function for the player to skip the movement of the dialogue
    public void SkipText()
    {
        currentSentenceNumber = currentSentence.ToCharArray().Length - 1;
        textToBeEdited.text = currentSentence;
        playingClip.Stop();
    }

    public void ContinueText()
    {
        if(currentConversation == null)
        {
            return;
        }
        if(currentSentenceIndex >= currentConversation.Length - 1 && currentSentenceNumber >= currentSentence.ToCharArray().Length - 1)
        {
            EndConversation();
        }

        else
        {
            Debug.Log(currentSentenceNumber);
            Debug.Log(currentSentence.ToCharArray().Length);
            if(currentSentenceNumber < currentSentence.ToCharArray().Length - 1)
            {
                SkipText();
                return;
            }
            currentSentenceIndex++;
            currentSentence = currentConversation[currentSentenceIndex].line;
            sentenceRead = false;
            currentSentenceNumber = 0;
            ChangeHeadshot(currentConversation[currentSentenceIndex].speaker);
        }
    }

    void ChangeHeadshot(int headshotIndex)
    {
        Texture headShotImage = null;
        if (availableHeadshots[headshotIndex] != null)
            headShotImage = availableHeadshots[headshotIndex];

        if(headShotImage != null)
        {
            headShotSprite.texture = headShotImage;
        }

        playingClip.Stop();
        playingClip.clip = availableClips[headshotIndex];
        playingClip.Play();
    }

    //Function to end the conversation, Returning the player to the usual gameplay
    void EndConversation()
    {
        if(convo.activation != null & convo.activation.Length > 0)
        {
            foreach(GameObject activate in convo.activation)
            {
                activate.SetActive(true);
            }
        }

        if (convo.deActivation != null & convo.deActivation.Length > 0)
        {
            foreach (GameObject activate in convo.deActivation)
            {
                activate.SetActive(false);
            }
        }
        currentConversation = null;
        player.reading = false;
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
            playingClip.Stop();

        }

        if (currentSentenceNumber >= fullSentence.Length)
        {
            playingClip.Stop();
            return false;
        }

        return true;
    }

    public void DeathTimer(int addToThis)
    {
        deathTimer += addToThis;
        if(deathTimer == 3)
        {
            //switch to cutscene scene
            SceneManager.LoadScene(2);
        }
    }
}
