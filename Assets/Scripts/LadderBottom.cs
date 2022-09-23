using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBottom : MonoBehaviour
{
    public bool onBottom;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            onBottom = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
             onBottom = false;    
        }
    }
}
