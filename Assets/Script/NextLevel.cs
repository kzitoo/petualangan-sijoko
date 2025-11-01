using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int Level;

    private void OnTriggerEnter2D(Collider2D other){
        print("Enter");

        if(other.tag == "Player"){
            print("Pindah Level " + Level);
            SceneManager.LoadScene(Level, LoadSceneMode.Single);
        }
    }

}
