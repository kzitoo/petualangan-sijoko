using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField]private float atkcd;
    [SerializeField]private float range;
    [SerializeField]private int Damage;
    [SerializeField]private float ColliderDistance;
    private float cdTimer=Mathf.Infinity;
    [SerializeField]private BoxCollider2D BoxCollider;
    [SerializeField]private LayerMask playerLayer;
    private Animator anim;
    private Health PlayerHealth;
    [SerializeField]private float MaxEnemyHealth;
    private EnemyJalan enemyJalan;
    private float CurrentHealth;
    private void Start(){
        anim=GetComponent<Animator>();
        enemyJalan = GetComponentInParent<EnemyJalan>();
        CurrentHealth=MaxEnemyHealth;
    }
    private void Update(){
        cdTimer+=Time.deltaTime;
        //Attack player in sight?
        if(PlayerInSight()){

        if(cdTimer >=atkcd ){
            //Attack
            cdTimer =0;
            anim.SetTrigger("Attack");
        }
        }
        
        if(enemyJalan != null)
        enemyJalan.enabled = !PlayerInSight();
    }
    
    private bool PlayerInSight(){
        RaycastHit2D hit = Physics2D.BoxCast(BoxCollider.bounds.center+transform.right*range*transform.localScale.x*ColliderDistance,
        new Vector3( BoxCollider.bounds.size.x * range,BoxCollider.bounds.size.y,BoxCollider.bounds.size.z)
       ,0,Vector2.left,0,playerLayer);

        if(hit.collider!=null)
            PlayerHealth=hit.transform.GetComponent<Health>();

        return hit.collider !=null ;
    }
    private void OnDrawGizmos(){
        Gizmos.color=Color.red;
        Gizmos.DrawWireCube(BoxCollider.bounds.center+transform.right*range*transform.localScale.x*ColliderDistance,
        new Vector3( BoxCollider.bounds.size.x * range,BoxCollider.bounds.size.y,BoxCollider.bounds.size.z));
    }

    private void DamagePlayer(){
        if(PlayerInSight()){
            //Damage Player
            PlayerHealth.takeDamage(Damage);
        }
    }
    public void TakeDamage(float Damage){
        CurrentHealth-=Damage;
        Debug.Log(Damage);
        if(CurrentHealth<=0)
        {
            Die();
        }
    }
    void Die(){
        Debug.Log("mati");
        
    }
}
