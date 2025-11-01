using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public float attackDamage;

	private float timeBtwAttack;
	public float startTimeBtwAttack;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
	Animator anim;
	void Start(){
		anim=GetComponent<Animator>();
}
	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			if (timeBtwAttack <= 0)
			{timeBtwAttack = startTimeBtwAttack;
				colInfo.GetComponent<Health>().takeDamage(attackDamage);
			}
			else {
				timeBtwAttack -= Time.fixedDeltaTime;
			}
	}
}
}
