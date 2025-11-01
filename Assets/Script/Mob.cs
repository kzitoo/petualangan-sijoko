using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mob : MonoBehaviour
{
    public int health;
    private Animator myAnim;
    public GameObject bloodEffect;

    void Start()
    {
        myAnim = GetComponent<Animator>();

    }

    void Update ()
    {
        if(health <= 0)
        {
            
            Dead();
        }
    }

    public void Damage (int damage)
    {
        GameObject ps = (GameObject)Instantiate(bloodEffect, transform.position, Quaternion.identity);
        Destroy(ps, 1f);
        health -= damage;
        Debug.Log("Hit Wir");
    }
    public void Dead(){
        Destroy(gameObject);
    }
}
