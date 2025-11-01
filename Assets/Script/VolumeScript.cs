using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class VolumeScript : MonoBehaviour
{
    [SerializeField]private AudioMixer audioMixer;
    [SerializeField]private Slider SliderMusic;
    [SerializeField]private Slider SliderSFX;
    // Start is called before the first frame update
    public void SetVolumeMusic(){
        float Volume=SliderMusic.value;
        audioMixer.SetFloat("MusicVolume",Mathf.Log10(Volume)*20);
    }
    public void SetVolumeSFX(){
        float Volume=SliderSFX.value;
        audioMixer.SetFloat("SFXVolume",Mathf.Log10(Volume)*20);
    }
}
