using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip footstep1, footstep2;
    public void FootStepSoundOne()
    {
        source.PlayOneShot(footstep1);
    }

    public void FootStepSoundTwo()
    {
        source.PlayOneShot(footstep2);
    }
}
