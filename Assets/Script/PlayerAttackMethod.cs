using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
	public class PlayerAttackMethod : MonoBehaviour
	{
		private float timeBtwAttack;
		public float startTimeBtwAttack;

		public Transform attackPos;
		public LayerMask whatIsEnemies;
		public LayerMask whatIsBoss;
		private Animator myAnim;
		public float attackRange;
		public int damage;
		GameObject[] enemies;
		public GameObject InvisibleWall;
		public TMP_Text NextLevel;
		AudioManager audioManager;
		GameObject[] boss;
		 void Awake()
    	{
        	myAnim = GetComponent<Animator>();
			audioManager=GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
			NextLevel.SetText("");
    	}

		

		void Update(){	
		if (timeBtwAttack <= 0)
			{
				if(Input.GetMouseButtonDown(0)){
				audioManager.PlaySfx(audioManager.swordSlash); 
				timeBtwAttack = startTimeBtwAttack;
				myAnim.SetTrigger("Attack01");
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
				if(enemiesToDamage.Length!=0){
				for (int i = 0; i < enemiesToDamage.Length; i++)
				{
					audioManager.StopSFX(audioManager.swordSlash);
					enemiesToDamage[i].GetComponent<Mob>().Damage(damage);
					audioManager.PlaySfx(audioManager.swordHit);
				}
				}
				else {
					Collider2D[] bossToDamage =Physics2D.OverlapCircleAll(attackPos.position,attackRange,whatIsBoss);
					for(int i=0;i< bossToDamage.Length;i++){
						audioManager.StopSFX(audioManager.swordSlash);
						bossToDamage[i].GetComponent<BossMob>().Damage(damage);
						audioManager.PlaySfx(audioManager.swordHit);
					}
				}
			}
		 enemies = GameObject.FindGameObjectsWithTag("Enemy");
		 boss =GameObject.FindGameObjectsWithTag("Boss");
			if(enemies.Length!=0){
				NextLevel.SetText("");
			}
			else if(boss.Length!=0){
				NextLevel.SetText("Kalahkan Boss Untuk Menang");
			}
			else {
				InvisibleWall.GetComponent<BoxCollider2D>().enabled=false;
				NextLevel.SetText("Pergi Ke Kanan Untuk Pergi Ke Level Selanjutnuya!");
			}

		}
					else {
				timeBtwAttack -= Time.fixedDeltaTime;
			}
		}
		void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(attackPos.position, attackRange);
		}
    }

