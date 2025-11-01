using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Import untuk mengatur Scene
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject PauseBtn;
    public bool isPaused;
    public GameObject player;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        PauseBtn.SetActive(true);
        audioManager=GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused){
                PauseGame();
                        
            }
            else {
                ResumeGame();
                        
            }
        }
    }
   public void PauseFunction()
    {
        if(!isPaused)
        {
            PauseGame();
        }
    }
    public void PauseGame(){
        audioManager.PlaySfx(audioManager.buttonSound);
        PauseMenu.SetActive(true);
        Time.timeScale=0f;
        player.GetComponent<PlayerAttackMethod>().enabled=false;
        isPaused=true;
        PauseBtn.SetActive(false);
    }
    public void ResumeGame(){
        audioManager.PlaySfx(audioManager.buttonSound);
        PauseMenu.SetActive(false);
        player.GetComponent<PlayerAttackMethod>().enabled=true;
        Time.timeScale=1f;
        isPaused=false;
        PauseBtn.SetActive(true);
    }
    public void Home(){
        //Kembali ke Home
        audioManager.PlaySfx(audioManager.buttonSound);
        PauseMenu.SetActive(false);
        isPaused=false;
        SceneManager.LoadSceneAsync(0);
        PauseBtn.SetActive(false);
    }
}