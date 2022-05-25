using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios; 
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SelectAudio(int i)
    {
        audioSource.clip = audios[i];
        audioSource.Play();
    }
}
