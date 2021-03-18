using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip coinPickUp;
    [SerializeField] private AudioClip boxPickUp;
    [SerializeField] private AudioClip boxDestroy;

    public AudioClip CoinPickUp { get => coinPickUp; }
    public AudioClip BoxPickUp { get => boxPickUp; }
    public AudioClip BoxDestroy { get => boxDestroy; }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
