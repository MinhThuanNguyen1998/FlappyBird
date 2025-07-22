using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_Flying;
    [SerializeField] private AudioClip m_GameOver;

    /// <summary>
    /// Plays the flying sound when the bird flaps its wings
    /// </summary>
    public void PlayFlyingSound()
    {
        m_AudioSource.clip = m_Flying;
        m_AudioSource.Play();
    }
    /// <summary>
    /// Plays the game over sound when the game ends
    /// </summary>
    public void PlayGameOverSound()
    {
        m_AudioSource.clip = m_GameOver;
        m_AudioSource.Play();
        
    }
}
