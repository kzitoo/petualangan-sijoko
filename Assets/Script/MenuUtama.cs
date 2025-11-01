using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Import mengatur Scene
using UnityEngine.SceneManagement;

public class MenuUtama : MonoBehaviour
{

    //Mulai game dengan pergi ke scene(1) yaitu index Ingame
    AudioManager audioManager;
    public GameObject SettingMenu;
    void Start(){
        SettingMenu.SetActive(false);
        audioManager=GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void StartGame(){
        audioManager.PlaySfx(audioManager.buttonSound);
        SceneManager.LoadSceneAsync(1);
    }
    //Quit game dengan klik button
    public void QuitGame(){
        audioManager.PlaySfx(audioManager.buttonSound);
        Application.Quit();
    }
    public void Settings(){
        audioManager.PlaySfx(audioManager.buttonSound);
        SettingMenu.SetActive(true);
    }
    public void Keluar(){
        audioManager.PlaySfx(audioManager.buttonSound);
        SettingMenu.SetActive(false);
    }
}
