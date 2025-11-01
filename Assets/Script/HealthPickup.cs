using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField]private float healthValue;
    Health health;

    void Awake()
    {
      health = FindObjectOfType<Health>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(health.currentHealth < 3){
            collision.GetComponent<Health>().AddHealt(healthValue);
            gameObject.SetActive(false);
            }
        }
    }
}
