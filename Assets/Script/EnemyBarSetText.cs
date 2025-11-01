using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyBarSetText : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] enemies;
    GameObject[] maxEnemies;
    public TMP_Text enemyBarText;
    void Start()
    {
        enemies=GameObject.FindGameObjectsWithTag("Enemy");
        maxEnemies=GameObject.FindGameObjectsWithTag("Enemy");
        enemyBarText.SetText("Enemy "+enemies.Length+"/"+maxEnemies.Length);
    }

    // Update is called once per frame
    void Update()
    {
        enemies=GameObject.FindGameObjectsWithTag("Enemy");
        enemyBarText.SetText("Enemy "+enemies.Length+"/"+maxEnemies.Length);
    }
}
