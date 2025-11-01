using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXSource;
    public string BossLevel="BossLevel";
    public string NamaScene;
    public AudioClip background;
    public AudioClip backgroundBoss;
    public AudioClip death;
    public AudioClip swordSlash;
    public AudioClip Dash;
    public AudioClip Hurt;
    public AudioClip swordHit;
    public AudioClip Run;
    public AudioClip Victory;
    public AudioClip buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        NamaScene=SceneManager.GetActiveScene().name;
                
        musicSource.clip= background;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.A)){
            PlaySfx(Run);
        }
        else if(Input.GetKeyUp(KeyCode.D)||Input.GetKeyUp(KeyCode.A)){
            StopSFX(Run);
        }

        else if(Input.GetKeyDown(KeyCode.W)){
            SFXSource.PlayOneShot(Dash); 
        }
    }
    public void PlaySfx(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void StopSFX(AudioClip clip)
    {
        SFXSource.Stop();
    }
    public void MusicSourceStop(){
        musicSource.Stop();
    }
    public void MusicSourceStart(AudioClip clip){
        musicSource.clip=clip;
        musicSource.Play();
    }
}
