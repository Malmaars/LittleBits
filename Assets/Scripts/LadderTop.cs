using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player.isClimbing && Input.GetAxis("Vertical") > 0)
            {
                player.canClimb = false;
                player.isClimbing = false;
                Debug.Log("Stop climbing");
            }
        }
    }
}
