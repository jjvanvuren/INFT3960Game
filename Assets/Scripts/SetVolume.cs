using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel (float sliderValue)
    {
        float vol = sliderValue;

        // Mute the volume if dB is less than 40
        if (sliderValue < -40)
        {
            vol = -80;
        }

        mixer.SetFloat("MainVol", vol);
    }
}
