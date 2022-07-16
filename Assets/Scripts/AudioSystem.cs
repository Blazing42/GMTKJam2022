using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSystem : MonoBehaviour
{
     AudioSource audioSource;

    public static AudioSystem AudioSystemInstance { get; private set; }

    private void Awake()
    {
        // If there is an instance
        if (AudioSystemInstance != null && AudioSystemInstance != this)
        {
            Destroy(this);
        }
        else
        {
            AudioSystemInstance = this;
        }
    }

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioCLip(AudioClip sfx, float volume)
    {
        if(audioSource != null)
        audioSource.PlayOneShot(sfx, volume);
    }

}
