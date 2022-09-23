using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    LadderBottom bottom;
    bool onBottom;

    private void Start()
    {
        bottom = GetComponentInChildren<LadderBottom>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.canClimb = true;
            player.currentLadder = transform.gameObject;
            Debug.Log("player is in front of ladder");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.onBottom = bottom.onBottom;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.canClimb = false;
            player.currentLadder = null;

            if (player.isClimbing)
            {
                player.rb.gravityScale = 1;
                player.rb.velocity = new Vector2(player.rb.velocity.x, 0);
            }
            player.onBottom = false;
        }
    }
}
