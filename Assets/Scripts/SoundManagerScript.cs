using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Source: https://www.youtube.com/watch?v=8pFlnyfRfRc
    public static AudioClip baccyHurtSound, eryHurtSound, deathSound, jumpSound, pickUpWBCSound, throwWBCSound, levelChangeSound;
    static AudioSource audioSource;

    void Start()
    {
        baccyHurtSound = Resources.Load<AudioClip>("BaccyHurt");
        eryHurtSound = Resources.Load<AudioClip>("EryHurt");
        deathSound = Resources.Load<AudioClip>("Death");
        jumpSound = Resources.Load<AudioClip>("Jump");
        pickUpWBCSound = Resources.Load<AudioClip>("PickUpWBC");
        throwWBCSound = Resources.Load<AudioClip>("ThrowWBC");
        levelChangeSound = Resources.Load<AudioClip>("LevelChange");

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "BaccyHurt":
                audioSource.PlayOneShot(baccyHurtSound);
                break;
            case "EryHurt":
                audioSource.PlayOneShot(eryHurtSound);
                break;
            case "Death":
                audioSource.PlayOneShot(deathSound);
                break;
            case "Jump":
                audioSource.PlayOneShot(jumpSound);
                break;
            case "PickUpWBC":
                audioSource.PlayOneShot(pickUpWBCSound);
                break;
            case "ThrowWBC":
                audioSource.PlayOneShot(throwWBCSound);
                break;
            case "LevelChange":
                audioSource.PlayOneShot(levelChangeSound);
                break;

        }
    }
}
