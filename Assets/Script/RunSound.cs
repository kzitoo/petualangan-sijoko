using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSound : MonoBehaviour
{
    public GameObject runSound;
    void Start(){

        runSound.SetActive(false);
    }
    void Update(){
        
    }
    void Playsound(){
        Debug.Log("Jalan");
        runSound.SetActive(true);
    }
    void Stopsound(){
        Debug.Log("tidak jalan");
        runSound.SetActive(false);

    }
}
