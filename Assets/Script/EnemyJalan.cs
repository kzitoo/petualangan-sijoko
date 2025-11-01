using UnityEngine;

public class EnemyJalan : MonoBehaviour
{
    [Header("patrol points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    
    [Header("Enemy")]
    [SerializeField]private Transform enemy;

    
    [Header("Movement parameters")]
    [SerializeField]private float speed;
    private Vector3 initScale;
    private bool Movingleft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField]private Animator anim;

   
    private void Awake()
    {
        initScale= enemy.localScale;

    }

    private void OnDisable ()
    {
        if (anim != null){
        anim.SetBool("Walk",false);
        }
    }


    private void Update(){

        if(enemy != null){
        if(Movingleft)
        {
            if(enemy.position.x>=leftEdge.position.x)
            MoveInDirection(-1);
            else
            
                DirectionChange();
            
        }
        else
        {
             if(enemy.position.x<=rightEdge.position.x)
            MoveInDirection(1);
             else
        
                DirectionChange();
            
        }
        }

    }

    private void DirectionChange()
    {
        anim.SetBool("Walk",false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            Movingleft = !Movingleft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("Walk",true);
        //make enemy face direction
        enemy.localScale=new Vector3 (Mathf.Abs(initScale.x)*_direction,
        initScale.y,initScale.z);
        //move in that direction
        enemy.position = new Vector3(enemy.position.x+ Time.deltaTime*_direction*speed,enemy.position.y,enemy.position.z);
        
    }
}
