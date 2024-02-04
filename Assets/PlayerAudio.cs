using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip footstep1, footstep2;
    public void FootStepSoundOne()
    {
        //Debug.LogError("Playing foot sound one");
        source.PlayOneShot(footstep1, 1);
    }

    public void FootStepSoundTwo()
    {
        //Debug.LogError("Playing foot sound two");
        source.PlayOneShot(footstep2, 1);
    }
}
