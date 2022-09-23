using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum functions {talk, adjust, build};

    public functions thisFunction;

    bool keyPressed;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)){
            keyPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            keyPressed = false;
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
                switch (thisFunction)
                {
                    case functions.talk:
                        Talk();
                        break;
                    case functions.adjust:
                        Adjust();
                        break;
                    case functions.build:
                        BuildMode();
                        break;
                }

                keyPressed = false;
            }
        }
    }

    void Talk()
    {
        Debug.Log("You can talk with me");
    }

    void Adjust()
    {
        Debug.Log("You can Adjust my settings");
    }

    void BuildMode()
    {
        //activate build mode
    }
}
