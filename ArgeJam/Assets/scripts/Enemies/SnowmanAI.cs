using Unity.VisualScripting;
using UnityEngine;

public class SnowmanAI : MonoBehaviour
{
    public float speed = 2f; // Hareket h�z�
    private int currentPointIndex = 0; // �u anda hedeflenen noktan�n indeksi
    private Animator anim;
    public RaycastHit2D hit;
    public GameObject player;
    public LayerMask detectionLayer;
    [SerializeField] private Transform firePoint;
    public float viewDistance;
    private bool isPlayerDetected = false;
    public float attackRange;
    public float viewRange;
    private bool canAttack;
    public float attackDistance = 2;
    private Vector2 direction;
    public float damage;
    public float snowballCooldownTimer=0;
    public float snowballCooldownTime;
    public GameObject[] snowballs;
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
        Attack();
        if (isPlayerDetected == true && canAttack == false)
        {
            Move();

        }
        
        snowballCooldownTimer+=Time.deltaTime;

    }

    private void Attack()
    {
        if (transform.localScale.x > 0)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        hit = Physics2D.CircleCast(transform.position , attackRange, direction, 0, detectionLayer);

        if (hit.collider != null && hit.transform.tag == "Player") 
        {
            anim.SetBool("isAttacking", true);
            canAttack = true;
        }
        else
        {
            anim.SetBool("isAttacking", false);
            canAttack = false;
        }

    }

    private void ThrowSnowball()
    {
        if (canAttack==true && snowballCooldownTimer > snowballCooldownTime)
        {
            int index;
            for (index = 0; index < snowballs.Length; index++)
            {
                if (snowballs[index].gameObject.activeInHierarchy == false)
                {
                    break;
                }
            }
            Vector2 shootingDirection;
            shootingDirection.x = player.transform.position.x - transform.position.x;
            shootingDirection.y = player.transform.position.y - transform.position.y;
            snowballs[index].transform.position = firePoint.position;
            snowballs[index].GetComponent<Snowball>().SetDirection(shootingDirection);
            snowballCooldownTimer = 0;
        }
    }

    public void GiveDamage()
    {
        deneme character = null;
        if (hit.collider != null)
        {
            character = hit.collider.GetComponent<deneme>();
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
        if (transform.localScale.x > 0)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        RaycastHit2D hit = Physics2D.BoxCast(new Vector3(transform.position.x + direction.x * viewDistance, transform.position.y, transform.position.z), new Vector3(viewDistance * viewRange, viewRange, transform.position.z), 0, direction, 0, detectionLayer);

        if (hit.collider != null && hit.collider.tag == "Player")
        {

            Debug.DrawLine(transform.position, hit.transform.position, Color.green);
            return true;

        }
        else
        {
            return false;
        }

    }

    // Tespit alan�n� sahnede g�rselle�tirmek i�in
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
        Gizmos.DrawWireCube(new Vector3(transform.position.x + direction.x * viewDistance, transform.position.y, transform.position.z), new Vector3(viewDistance * viewRange, viewRange, transform.position.z));
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
