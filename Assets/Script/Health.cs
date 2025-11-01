using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator anim;
    private bool dead=false;
    private Transform spawnPoint;
    private Transform posisiPlayer;
    public GameObject respawnMenu;
    public GameObject pauseBtn;
    public GameObject player;
    PlayerMovementData Data;
    AudioManager audioManager;

    private void Awake()
    {
    currentHealth = startingHealth;
    anim = GetComponent<Animator>();
    respawnMenu.SetActive(false);
    posisiPlayer=GameObject.FindGameObjectWithTag("Player").transform;
    spawnPoint=GameObject.FindGameObjectWithTag("Respawn").transform;
    Time.timeScale=1f;
    audioManager=GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void takeDamage(float damage)
    {
        currentHealth = Mathf.Clamp (currentHealth - damage, 0 , startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            audioManager.PlaySfx(audioManager.Hurt); 
        }
        else 
        {
            if(!dead)
            {
                anim.SetTrigger("Death");
                audioManager.PlaySfx(audioManager.death); 
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                pauseBtn.SetActive(false);
                        GetComponent<PlayerAttackMethod>().enabled=false;
                Invoke("RespawnMenuActive",1f);
                }
        }
    }

    public void AddHealt(float value)
    {
        currentHealth = Mathf.Clamp (currentHealth + value, 0 , startingHealth);
    }
    public void RespawnMenuActive(){
        Time.timeScale=0f;
        respawnMenu.SetActive(true);
    }
    public void Respawn(){
        audioManager.PlaySfx(audioManager.buttonSound);
        //tidak dead
        RespawnClicked();
    }
    public void RespawnClicked(){
        dead=false;
        //Menu Respawn hilang
        respawnMenu.SetActive(false);
        //Mengatur darah menjadi max
        currentHealth=startingHealth;
        //Menjalankan waktunya kembali
        Time.timeScale=1f;
        //PauseBtn dimunculkan lagi
        pauseBtn.SetActive(true);
        GetComponent<PlayerAttackMethod>().enabled=true;
        //Player bisa bergerak
        GetComponent<PlayerMovement>().enabled=true;
        //Posisi player ke posisi respawn
        posisiPlayer.position=new Vector2(spawnPoint.position.x,spawnPoint.position.y);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}