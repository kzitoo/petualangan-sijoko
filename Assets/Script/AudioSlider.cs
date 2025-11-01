using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AudioSlider : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] TMP_Text volumeText;
    public int Value;
    float ValueFloat;
    // Update is called once per frame
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume",1);
            Load();
        }
        else {
            Load();
        }
    }
    void Update(){
        ValueFloat=volumeSlider.value*100;
        Value=(int)(ValueFloat);
        string value=Value.ToString()+"%";
        volumeText.SetText(value);
    }
    public void ChangeVolume()
    {
        AudioListener.volume=volumeSlider.value;
    }
    private void Load()
    {
        volumeSlider.value=PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume",volumeSlider.value);
    }
}
