using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum functions {talk, interact, activateObject};

    public functions[] thisFunction;

    public GameObject[] objectsToActive;
    public GameObject[] objectsToDeActive;
    int objectIndex;

    public Conversation conversations;
    public int currentConvo;

    Dialogue dialogue;
    GameObject buttonPrompt;

    bool keyPressed;

    bool keyPressedA;

    public float interactingTimer;
    public int addThis;

    Player player;

    private void Start()
    {
        buttonPrompt = transform.GetChild(0).gameObject;
        buttonPrompt.SetActive(false);
        dialogue = FindObjectOfType<Dialogue>();
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if (!player.reading)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                keyPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                keyPressedA = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            keyPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            keyPressedA = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("I SEE THE PLAYER!!! INTERACT WITH MEEEE");
            //if player presses the "A" or "B" button: perform function
            if (keyPressed)
            {
                for (int i = 0; i < thisFunction.Length; i++)
                {
                    switch (thisFunction[i])
                    {
                        case functions.talk:
                            Talk();
                            break;
                        case functions.interact:
                            Interact();
                            break;
                    }

                    keyPressed = false;
                }
            }

            if (keyPressedA)
            {
                for (int i = 0; i < thisFunction.Length; i++)
                {
                    switch (thisFunction[i])
                    {
                        case functions.talk:
                            Talk();
                            break;
                    }
                    keyPressedA = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        buttonPrompt.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonPrompt.SetActive(false);
    }

    void Talk()
    {
        dialogue.InitiateNewConversation(conversations);
    }

    void Interact()
    {
        player.interacting = true;
        StartCoroutine(WaitWhileInteracting());
        //timer
        //player.interacting = false;
    }

    void ActivateObject(GameObject objectToActivate)
    {
        objectIndex++;
        //activate Object
    }

    private IEnumerator WaitWhileInteracting()
    {
        yield return new WaitForSeconds(interactingTimer);
        player.interacting = false;

        foreach(GameObject activate in objectsToActive)
        {
            activate.SetActive(true);
        }

        foreach (GameObject activate in objectsToDeActive)
        {
            activate.SetActive(false);
        }

        dialogue.DeathTimer(addThis);
    }
}
