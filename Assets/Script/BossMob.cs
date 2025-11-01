using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossMob : MonoBehaviour
{
    public int health;
    private Animator myAnim;
    public GameObject bloodEffect;
    AudioManager audioManager;
    public GameObject player;
    public GameObject pauseBtn;
    [SerializeField] private Slider _slider;

    void Awake(){
        audioManager=GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        player=GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        myAnim = GetComponent<Animator>();
        _slider.value = health;

    }

    void Update ()
    {
        if(health <= 0)
        {
            
            Dead();
        }
    }

    public void Damage(int damage)
    {
        GameObject ps = (GameObject)Instantiate(bloodEffect, transform.position, Quaternion.identity);
        Destroy(ps, 1f);
        health -= damage;
        _slider.value = health;
        Debug.Log("Hit Wir");
    }
    public void Dead(){
        myAnim.SetTrigger("mokad");

        audioManager.MusicSourceStop();
        audioManager.StopSFX(audioManager.Victory);
        audioManager.PlaySfx(audioManager.Victory);
        player.GetComponent<PlayerAttackMethod>().enabled=false;
        player.GetComponent<PlayerMovement>().enabled=false;
        pauseBtn.SetActive(false);
        Destroy(gameObject, 1f);
        Invoke("DeadTime",1f);
    }
    public void DeadTime(){
        Time.timeScale=0f;
    }
}
