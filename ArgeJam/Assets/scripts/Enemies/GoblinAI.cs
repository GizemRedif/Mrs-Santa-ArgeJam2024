using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GoblinAI : MonoBehaviour
{
    public float speed = 2f; // Hareket hýzý
    private int currentPointIndex = 0; // Þu anda hedeflenen noktanýn indeksi
    private Animator anim;
    public RaycastHit2D hit;
    public GameObject player;
    public LayerMask detectionLayer;
    public float viewDistance;
    private bool isPlayerDetected = false;
    public float attackRange;
    public float viewRange;
    private bool canAttack;
    public float attackDistance=2;
    private Vector2 direction;
    private Vector2 gizmosMovement;
    public float damage;
    void Start()
    {

    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        isPlayerDetected = DetectPlayer();
        
        if (isPlayerDetected == true && canAttack==false)
        {
            Move();
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        Attack();

    }

    private void Attack()
    {
        if(transform.localScale.x>0)
        {
            direction = Vector2.right;
        }
        else
        {
             direction = Vector2.left;
        }
        
        hit = Physics2D.CircleCast(transform.position + new Vector3(attackDistance * direction.x, -0.5f, 0), attackRange, direction, 0, detectionLayer);

        if (hit.collider != null && hit.transform.tag=="Player")
        {
            Debug.Log("Attack");
            anim.SetBool("isAttacking",true);
            canAttack = true;
        }
        else
        {
            anim.SetBool("isAttacking", false);
            canAttack = false;
        }

    }

    public void GiveDamage()
    {
        deneme character=null;
        if (hit.collider != null)
        {
            character= hit.collider.GetComponent<deneme>();
        }
        
        if (character != null)
        {
            character.takedamage(damage);
        }
    }

    private void Move()
    {
        
        anim.SetBool("isRunning", true);
        SetDirection(player.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void SetDirection(Vector2 targetDirection)
    {
        if (targetDirection.x > transform.position.x)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

        }
    }

    private bool DetectPlayer()
    {
        
        Vector2 direction;
        if (transform.localScale.x>0)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        RaycastHit2D hit = Physics2D.BoxCast(new Vector3(transform.position.x + direction.x*viewDistance, transform.position.y, transform.position.z), new Vector3(viewDistance * viewRange, viewRange, transform.position.z), 0, direction, 0, detectionLayer);

        if (hit.collider != null && hit.collider.tag=="Player")
        {
            
            Debug.DrawLine(transform.position, hit.transform.position, Color.green);
            return true;
 
        }
        else
        {
            return false;
        }

    }

    // Tespit alanýný sahnede görselleþtirmek için
    private void OnDrawGizmos()
    {

        if (transform.localScale.x > 0)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(transform.position.x + direction.x*viewDistance, transform.position.y, transform.position.z), new Vector3(viewDistance * viewRange, viewRange, transform.position.z));
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + new Vector3(attackDistance * direction.x, -0.5f, 0), attackRange);
    }
}