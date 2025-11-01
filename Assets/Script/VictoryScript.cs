using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryScript : MonoBehaviour
{ 
    public GameObject VictoryMenu;
    public GameObject mainMenu;
    public GameObject backToLvl1;
    GameObject[] BossEnemy;
    // Start is called before the first frame update
    void Start()
    {
        VictoryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        BossEnemy=GameObject.FindGameObjectsWithTag("Boss");
        if(BossEnemy.Length==0){
            TampilkanMenu();
        }
    }
    void TampilkanMenu(){
        VictoryMenu.SetActive(true);
    }        
    public void MenuUtama(){
        VictoryMenu.SetActive(false);
        SceneManager.LoadSceneAsync(0);
    }
    public void LVL1(){
        VictoryMenu.SetActive(false);
        SceneManager.LoadSceneAsync(2);
    }
}
