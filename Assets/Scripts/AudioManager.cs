using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioclips;
    private AudioSource audioSources;
    [SerializeField]
    private AudioSource bgmAudioSources;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = gameObject.AddComponent<AudioSource>();
        if (audioSources == null)
        {
            Debug.Log("audio is null");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(int _idx) {

        audioSources.clip = audioclips[_idx];
        audioSources.Play();
    
    }

    public void soundVolume(float  val)
    {
        audioSources.volume = val;
    }
    public void BGMVolume(float val)
    {
        bgmAudioSources.volume = val;
    }
}
