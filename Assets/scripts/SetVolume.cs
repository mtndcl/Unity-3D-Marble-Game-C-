using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
   public void Setlevel(float slidervalue){
        mixer.SetFloat("volume", slidervalue);
        Debug.Log("volume value "+slidervalue);
    }
}
