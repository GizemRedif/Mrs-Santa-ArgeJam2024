using System.Net.Mail;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deneme : MonoBehaviour
{
    public Transform attackpoint;
    public float attackDamage = 40;
    [SerializeField] float attackRange = 0.5f;
    public float movePower = 10f;
    public LayerMask enemyLayers;
    public float healthTimer = 0 ;
    public float maxHealthTime = 300;
    private Rigidbody2D rb;
    private Animator anim;
    private int direction = 1;
    private bool alive = true;
    private bool death = false;
    
    void Start()
    {
        healthTimer=PlayerPrefs.GetFloat("Timer");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        healthTimer=PlayerPrefs.GetFloat("Timer")-Time.deltaTime;
        PlayerPrefs.SetFloat("Timer",healthTimer);
        if(healthTimer<0)
        {
            Die();
        }
        if(alive){
            Run();
            Attack();
        }
    }
    void Run(){
        Vector3 moveVelocity = Vector3.zero;
        anim.SetBool("isRun", false);
        if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool("isRun", true);
                direction = -1;
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(direction,1, 1);
                
            }    
        if (Input.GetKey(KeyCode.D))
            {
                anim.SetBool("isRun", true);
                direction = 1;
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(direction,1, 1);
                
            }
        if(Input.GetKey(KeyCode.W)){
            anim.SetBool("isRun", true);
            moveVelocity = Vector3.up;
            
        }
        if(Input.GetKey(KeyCode.S)){
            anim.SetBool("isRun", true);
            moveVelocity = Vector3.down;
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
        //rb.MovePosition(rb.position + movePower * Time.deltaTime * moveVelocity);
    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");

            Collider2D hitEnemies = Physics2D.OverlapCircle(attackpoint.position, attackRange, enemyLayers);

            if (hitEnemies != null)
            {
                GoblinHealth goblin = hitEnemies.GetComponent<GoblinHealth>();
                if (goblin != null)
                {
                    goblin.TakeDamage(attackDamage);
                }
                SnowmanHealth snowman= hitEnemies.GetComponent<SnowmanHealth>();
                if(snowman!=null)
                {
                    snowman.TakeDamage(attackDamage);
                }
            
            }
        }
    }
    void Die()
    {
        if (death == false)
        {
            anim.SetTrigger("die");
            this.enabled = false;
            death = true;
            SceneManager.LoadScene("TimeOverEnd");

            Destroy(gameObject, 2f);

        }
    }
    void Hurt(){
        if(death==false)
        {
            anim.SetTrigger("takehit");
        }
        
    }
    public void takedamage(float damage){
        Hurt();
        healthTimer -= damage;
        PlayerPrefs.SetFloat("Timer",healthTimer);
        if(healthTimer <= 0 )
        {
            Die();
        }
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpoint.position,attackRange);  
    }
}
