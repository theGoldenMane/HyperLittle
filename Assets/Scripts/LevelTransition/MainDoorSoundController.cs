using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorSoundController : MonoBehaviour
{
	public AudioSource audioSrc;

    public void PlayDoorSound()
    {
        audioSrc.Play();
    }
}
